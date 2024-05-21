import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { CourseService } from 'src/app/services/course.service';
import { EnrollmentService } from 'src/app/services/enrollment.service';
import { MaterialService } from 'src/app/services/material.service'; // Import MaterialService

@Component({
  selector: 'app-studentviewcourse',
  templateUrl: './studentviewcourse.component.html',
  styleUrls: ['./studentviewcourse.component.css']
})
export class StudentviewcourseComponent implements OnInit {
  isEnrolling: boolean = false;
  availableCourses: any[] = [];
  filteredCourses = [];
  searchValue: string = '';
  sortValue: number = 0;
  page: number = 1;
  limit: number = 5;
  enrolledCourses: any[] = [];
  courses = [];
  showEnrollPopup = false;
  showMaterialPopup = false;
  selectedCourse: any;
  successMessage: string = '';
  materials: any[] = [];
  currentMaterialIndex: number = 0;
  currentMaterial: any = {};
  materialMessage: string = 'No Materials Found';

  constructor(
    private router: Router,
    private enrollservice: EnrollmentService,
    private courseservice: CourseService,
    private materialService: MaterialService // Inject MaterialService
  ) {}

  ngOnInit(): void {
    this.fetchData();
  }

  fetchData() {
    const userId = localStorage.getItem('userId');

    forkJoin({
      enrolledCourses: this.enrollservice.getEnrolledCourses(userId),
      allCourses: this.courseservice.getAllCourses()
    }).subscribe(
      ({ enrolledCourses, allCourses }) => {
        this.enrolledCourses = enrolledCourses;
        this.availableCourses = allCourses;
        this.filteredCourses = allCourses;
        console.log('Enrolled courses:', this.enrolledCourses);
        console.log('Available courses:', this.availableCourses);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  searchField = '';

  handleSearchChange(searchValue: string): void {
    this.searchField = searchValue;
    this.filteredCourses = this.filterCourses(searchValue);
  }

  filterCourses(search: string) {
    const searchLower = search.toLowerCase();
    if (searchLower === '') return this.availableCourses;
    return this.availableCourses.filter(
      (course) =>
        course.Title.toLowerCase().includes(searchLower) ||
        course.Description.toLowerCase().includes(searchLower)
    );
  }

  isCourseEnrolled(course: any): boolean {
    return this.enrolledCourses.some(
      (enrolledCourse) => enrolledCourse.CourseId === course.CourseId
    );
  }

  handleEnrollClick(course: any) {
    const isCourseEnrolled = this.isCourseEnrolled(course);

    if (isCourseEnrolled) {
      alert('You are already enrolled in this course.');
    } else {
      this.selectedCourse = course;
      this.showEnrollPopup = true;
    }
  }

  handleConfirmEnroll() {
    this.isEnrolling = true;
    const userId = localStorage.getItem('userId');
    this.enrollservice.enrollCourse(this.selectedCourse.CourseId, userId).subscribe(
      () => {
        this.enrolledCourses.push(this.selectedCourse);
        this.successMessage = 'Enrollment successful!';
      },
      (error) => {
        console.error('Error enrolling in course:', error);
        this.isEnrolling = false;
      }
    );
  }

  closeEnrollPopup() {
    this.showEnrollPopup = false;
    this.successMessage = '';
    this.isEnrolling = false;
  }

  handleViewMaterialClick(courseId: string) {
    this.materialService.getMaterialsByCourseId(courseId).subscribe(
      (response) => {
        console.log('Materials fetched:', response);
        this.materials = response;
        this.currentMaterialIndex = 0;
        if (this.materials.length > 0) {
          this.currentMaterial = this.materials[this.currentMaterialIndex];
        } else {
          this.materialMessage = 'No Materials Found';
        }
        this.showMaterialPopup = true;
      },
      (error) => {
        console.error('Error fetching materials:', error);
        this.materialMessage = 'No Materials Found';
        this.showMaterialPopup = true;
      }
    );
  }

  closeMaterialPopup() {
    this.showMaterialPopup = false;
    this.materials = [];
    this.currentMaterial = {};
  }

  nextMaterial() {
    if (this.currentMaterialIndex < this.materials.length - 1) {
      this.currentMaterialIndex++;
      this.currentMaterial = this.materials[this.currentMaterialIndex];
    }
  }

  previousMaterial() {
    if (this.currentMaterialIndex > 0) {
      this.currentMaterialIndex--;
      this.currentMaterial = this.materials[this.currentMaterialIndex];
    }
  }
}
