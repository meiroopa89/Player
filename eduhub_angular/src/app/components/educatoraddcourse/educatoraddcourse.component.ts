import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Course } from 'src/app/models/course.model';
import { CourseService } from 'src/app/services/course.service';

@Component({
  selector: 'app-educatoraddcourse',
  templateUrl: './educatoraddcourse.component.html',
  styleUrls: ['./educatoraddcourse.component.css']
})
export class EducatoraddcourseComponent implements OnInit {


  id: string;
  formData: Course = { // Use the Course interface to type the formData object
    CourseId: 0,
    Title: '',
    Description: '',
    CourseStartDate: null,
    CourseEndDate: null,
    Category: '',
    Level: ''
  };
  errors: any = {};
  errorMessage: string;
  successPopup: boolean = false;
  today = new Date().toISOString().split('T')[0];
  constructor(private courseService: CourseService, private router: Router) {}

  ngOnInit(): void {
    // Initialize your component here
  }

  handleChange(event: any, field: string) {
    this.formData[field] = event.target.value;
    // Validate your form here and set errors if any
  }

  onSubmit(courseForm: NgForm) {
    console.log('Form Validity:', courseForm.valid);
    if (courseForm.valid) {
      this.courseService.addCourse(this.formData).subscribe(
        (res) => {
          this.successPopup = true;
          console.log('Course added successfully', res);
          courseForm.resetForm();
        },
        (err) => {
          if (err.status === 500 && err.error.message) {
            this.errorMessage = 'A course with the same name already exists';
          } else {
            this.errors = err.error;
          }
          console.error('Error adding course:', err);
        }
      );
    } else {
      this.errorMessage = 'All fields are required';
    }
  }

  handleSuccessMessage() {
    this.successPopup = false;
    this.errorMessage = '';
    this.formData = {
      CourseId: 0,
      Title: '',
      Description: '',
      CourseStartDate: null,
      CourseEndDate: null,
      Category: '',
      Level: ''
    };
  }
}
