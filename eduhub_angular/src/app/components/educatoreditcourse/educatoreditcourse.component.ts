import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from 'src/app/services/course.service';
import { Course } from 'src/app/models/course.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-educatoreditcourse',
  templateUrl: './educatoreditcourse.component.html',
  styleUrls: ['./educatoreditcourse.component.css']
})
export class EducatoreditcourseComponent implements OnInit {

  id: string;
  errorMessage: string = '';
  formData: Course = { // Use the Course interface to type the formData object
    Title: '',
    Description: '',
    CourseStartDate: null,
    CourseEndDate: null,
    Category: '',
    Level: ''
  };
  errors: any = {};
  successPopup: boolean; // Add this line to declare the successPopup property

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private courseService: CourseService,
    private datePipe: DatePipe
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getCourseById();
  }

  getCourseById() {
    this.courseService.getCourseById(this.id).subscribe(
      (response) => {
        console.log('Course details:', response);
        this.formData = {
          Title: response.Title,
          Description: response.Description,
          CourseStartDate: this.datePipe.transform(new Date(response.CourseStartDate), 'yyyy-MM-dd'),
          CourseEndDate: this.datePipe.transform(new Date(response.CourseEndDate), 'yyyy-MM-dd'),
          Category: response.Category,
          Level: response.Level
        };
      },
      (error) => {
        console.error('Error fetching course details:', error);
        this.router.navigate(['/error']);
      }
    );
  }

  handleChange(event: any, field: string) {
    this.formData[field] = event.target.value;
    this.errors[field] = ''; // Clear error when the user makes a change
  }

  handleUpdateCourse(courseForm: NgForm) {
    if (courseForm.valid) {
      this.courseService.updateCourse(this.id, this.formData).subscribe(
        (response) => {
          console.log('Course updated successfully', response);
          this.successPopup = true;
          this.errorMessage = '';
        },
        (error) => {
          console.error('Error updating course:', error);
          this.errorMessage = error.error.message;
        }
      );
    }
  }

  handleOkClick() {
    // Close the success popup
    this.successPopup = false;
    this.router.navigate(['/educator/view/course']);
  }

  navigateToDashboard() {
    this.router.navigate(['/educator/view/course']);
  }
}
