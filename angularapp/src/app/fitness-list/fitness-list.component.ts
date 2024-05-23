import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FitnessService } from '../services/fitness.service'; // Adjusted service name
import { Fitness } from '../models/fitness.model'; // Adjusted model name

@Component({
  selector: 'app-fitness-list', // Adjusted selector
  templateUrl: './fitness-list.component.html', // Adjusted template URL
  styleUrls: ['./fitness-list.component.css'] // Adjusted style URL
})
export class FitnessListComponent implements OnInit {
  fitnessClasses: Fitness[] = []; // Adjusted property name

  constructor(private fitnessService: FitnessService, private router: Router) { } // Adjusted service name

  ngOnInit(): void {
    this.loadFitnessClasses(); // Adjusted method name
  }

  loadFitnessClasses(): void {
    this.fitnessService.getFitnessClasses().subscribe(fitnessClasses => { // Adjusted method name
      this.fitnessClasses = fitnessClasses;
      console.log(this.fitnessClasses);
    });
  }

  deleteFitnessClass(classId: number): void { // Adjusted method name and parameter
    // Navigate to confirm delete page with the class ID as a parameter
    this.router.navigate(['/confirmDelete', classId]);
  }
}
