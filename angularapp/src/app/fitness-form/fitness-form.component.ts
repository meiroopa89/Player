import { Component } from '@angular/core';
import { Fitness } from '../models/fitness.model';
import { Router } from '@angular/router';
import { FitnessService } from '../services/fitness.service';

@Component({
  selector: 'app-fitness-form',
  templateUrl: './fitness-form.component.html',
  styleUrls: ['./fitness-form.component.css']
})
export class FitnessFormComponent {
  newFitnessClass: Fitness = {
    fitnessId: 0,
    className: '',
    instructorName: '',
    classDate: '',
    duration: 0,
    location: ''
  };

  formSubmitted = false;

  constructor(private fitnessService: FitnessService, private router: Router) { }

  addFitnessClass(): void {
    this.formSubmitted = true;
    if (this.isFormValid()) {
      this.fitnessService.addFitnessClass(this.newFitnessClass).subscribe(() => {
        console.log('Fitness class added successfully!');
        this.router.navigate(['/viewFitnessClasses']);
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean {
    const fieldValue = this.newFitnessClass[fieldName];
    return !fieldValue && (this.formSubmitted || fieldValue?.touched);
  }

  isFormValid(): boolean {
    return !this.isFieldInvalid('className') && !this.isFieldInvalid('instructorName') &&
      !this.isFieldInvalid('classDate') && !this.isFieldInvalid('duration') &&
      !this.isFieldInvalid('location');
  }
}
