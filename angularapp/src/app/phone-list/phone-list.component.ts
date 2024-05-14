import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PhoneService } from '../services/phone.service';
import { Phone } from '../models/phone.model';

@Component({
  selector: 'app-phone-list', // Changed selector to 'app-phone-list'
  templateUrl: './phone-list.component.html', // Adjusted the template URL
  styleUrls: ['./phone-list.component.css'] // Adjusted the style URL
})
export class PhoneListComponent implements OnInit {
  phones: Phone[] = []; // Change recipes to phones

  constructor(private phoneService: PhoneService, private router: Router) { } // Adjust service name

  ngOnInit(): void {
    this.loadPhones(); // Adjusted the method name
  }

  loadPhones(): void {
    this.phoneService.getPhones().subscribe(phones => {
      this.phones = phones;
      console.log(this.phones);
    }); // Adjusted the service method name
  }

  deletePhone(phoneId: number): void { // Adjusted the method name and parameter
    // Navigate to confirm delete page with the phone ID as a parameter
    this.router.navigate(['/confirmDelete', phoneId]);
  }
}
