import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Fitness } from '../models/book.model'; // Adjusted model name
import { FitnessService } from '../services/book.service'; // Adjusted service name

@Component({
  selector: 'app-delete-confirm', // Component selector
  templateUrl: './delete-confirm.component.html',
  styleUrls: ['./delete-confirm.component.css']
})
export class DeleteConfirmComponent implements OnInit {
  fitnessId: number;
  fitnessClass: Fitness = {} as Fitness; // Initialize fitnessClass property with an empty object

  constructor(
    private route: ActivatedRoute, 
    private router: Router,
    private fitnessService: FitnessService // Adjusted service name
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.fitnessId = +params['id']; // Adjust parameter name
      this.fitnessService.getFitnessClass(this.fitnessId).subscribe(
        (fitnessClass: Fitness) => { // Adjust type casting
          this.fitnessClass = fitnessClass;
        },
        error => {
          console.error('Error fetching fitness class:', error);
        }
      );
    });
  }

  confirmDelete(fitnessId: number): void { // Adjust method signature
    this.fitnessService.deleteFitnessClass(fitnessId).subscribe(
      () => {
        console.log('Fitness class deleted successfully.');
        this.router.navigate(['/viewFitness']); // Adjust the route
      },
      (error) => {
        console.error('Error deleting fitness class:', error);
      }
    );
  }

  cancelDelete(): void {
    this.router.navigate(['/viewFitness']); // Adjust the route
  }
}
