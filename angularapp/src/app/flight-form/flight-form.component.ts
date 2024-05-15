import { Component } from '@angular/core';
import { Phone } from '../models/phone.model';
import { Router } from '@angular/router';
import { PhoneService } from '../services/phone.service';

@Component({
  selector: 'app-phone-form',
  templateUrl: './phone-form.component.html',
  styleUrls: ['./phone-form.component.css']
})
export class PhoneFormComponent {
  newPhone: Phone = {
    phoneId: 0,
    brand: '',
    model: '',
    screenSize: 0,
    storageCapacity: 0,
    ram: 0,
    batteryCapacity: 0
  }; // Initialize newPhone with empty fields

  formSubmitted = false; // Track form submission

  constructor(private phoneService: PhoneService, private router: Router) { }

  addPhone(): void {
    this.formSubmitted = true; // Set formSubmitted to true on form submission
    if (this.isFormValid()) {
      this.phoneService.addPhone(this.newPhone).subscribe(() => {
        console.log('Phone added successfully!');
        this.router.navigate(['/viewPhones']);
      });
    }
  }
  
  isFieldInvalid(fieldName: string): boolean {
    const fieldValue = this.newPhone[fieldName];
    return !fieldValue && (this.formSubmitted || fieldValue?.touched);
  }

  isFormValid(): boolean {
    return !this.isFieldInvalid('brand') && !this.isFieldInvalid('model') &&
      !this.isFieldInvalid('screenSize') && !this.isFieldInvalid('storageCapacity') &&
      !this.isFieldInvalid('ram') && !this.isFieldInvalid('batteryCapacity');
  }
}
