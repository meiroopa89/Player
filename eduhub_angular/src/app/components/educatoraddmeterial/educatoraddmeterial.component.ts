import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MaterialService } from 'src/app/services/material.service'; // Import your MaterialService
import { ActivatedRoute, Router } from '@angular/router';
import { Material } from 'src/app/models/material.model'; // Import your Material model

@Component({
  selector: 'app-educatoraddmeterial',
  templateUrl: './educatoraddmeterial.component.html',
  styleUrls: ['./educatoraddmeterial.component.css']
})
export class EducatoraddmeterialComponent implements OnInit {

  materialForm: FormGroup; // Rename to materialForm
  successPopup = false;
  errorMessage = "";
  courseId: number;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private materialService: MaterialService,
    private route: ActivatedRoute
  ) {
    this.materialForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
      url: ['', Validators.required],
      contentType: ['', Validators.required],
    });
  }

ngOnInit(): void {
  this.courseId = +this.route.snapshot.paramMap.get('courseId');
  console.log('courseId:', this.courseId);
}

  onSubmit(): void {
    if (this.materialForm.valid) {
      const formData = this.materialForm.value;
      const requestObject: Material = {
        CourseId: this.courseId,
        Title: formData.title,
        Description: formData.description,
        URL: formData.url,
        UploadDate: new Date().toISOString(),
        ContentType: formData.contentType,
      };

      this.materialService.addMaterial(requestObject).subscribe(
        (response) => {
          console.log('Response:', response);
          this.successPopup = true;
        },
        (error) => {
          console.error('Error submitting material:', error);
          // Handle error appropriately
        }
      );
    } else {
      this.errorMessage = "All fields are required"
    }
  }

  handleSuccessMessage(): void {
    this.successPopup = false;
    this.router.navigate(['/educator/view/course']); // Navigate to the desired route
  }

  navigateBack(): void {
    this.router.navigate(['/educator/view/course']); // Navigate to the desired route
  }
}
