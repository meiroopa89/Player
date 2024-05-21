import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnrollmentService } from 'src/app/services/enrollment.service';

@Component({
  selector: 'app-mycourse',
  templateUrl: './mycourse.component.html',
  styleUrls: ['./mycourse.component.css']
})
export class MycourseComponent implements OnInit {

  showEnrollPopup = false;
  courseToUnenroll: any = null;
  enrolledCourses: any[] = [];
  filteredCourses: any[] = [];
  searchValue = '';
  sortValue = 0;
  page = 1;
  limit = 5;
  maxRecords = 1;

  constructor(private enrollservice: EnrollmentService, private router: Router) {}

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    // Replace 'userId' with the actual user ID
    const userId = localStorage.getItem('userId');
    this.enrollservice.getEnrolledCourses(userId).subscribe(
      (response: any) => {
        this.enrolledCourses = response;
        console.log('User Enrolled courses:', this.enrolledCourses);
        this.filteredCourses = response;
        
        this.maxRecords = response.length;
      },
      (error) => {
        console.error('Error fetching data:', error);
        // Handle error appropriately
      }
    );
  }

  totalPages(): number {
    return Math.ceil(this.maxRecords / this.limit);
  }



  toggleSort(order: number): void {
    this.sortValue = order;

    this.filteredCourses.sort((a, b) => {
      return order === 1
        ? new Date(a.EnrollmentDate).getTime() -
            new Date(b.EnrollmentDate).getTime()
        : order === -1
        ? new Date(b.EnrollmentDate).getTime() -
          new Date(a.EnrollmentDate).getTime()
        : 0;
    });
  }

  handleUnenrollClick(course: any): void {
    this.courseToUnenroll = course;
    this.showEnrollPopup = true;
  }

  handleConfirmUnenroll(): void {
    this.enrollservice
        .unenrollCourse(this.courseToUnenroll.EnrollmentId)
        .subscribe((response) => {
            console.log('enrolledcourse deleted successfully', response);
            this.fetchData();
            this.closeEnrollPopup();
        });
  }

  closeEnrollPopup(): void {
    this.courseToUnenroll = null;
    this.showEnrollPopup = false;
  }
}
