import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PhoneService } from '../services/phone.service'; // Adjusted service name
import { Phone } from '../models/phone.model';

@Component({
  selector: 'app-delete-confirm',
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  phoneId: number;
  phone: Phone = {} as Phone; // Initialize phone property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private phoneService: PhoneService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.phoneId = +params['id']; // Adjust parameter name
      this.phoneService.getPhone(this.phoneId).subscribe(
        (phone: Phone) => {
          this.phone = phone;
        },
        error => {
          console.error('Error fetching phone:', error);
        }
      );
    });
  }

  confirmDelete(phoneId: number): void { // Adjust method signature
    this.phoneService.deletePhone(phoneId).subscribe(
      () => {
        console.log('Phone deleted successfully.');
        this.router.navigate(['/viewPhones']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting phone:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewPhones']); // Adjust the route
  }
}
