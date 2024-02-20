import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { VenueService } from 'src/app/services/venue.service';

@Component({
  selector: 'app-add-venue',
  templateUrl: './add-venue.component.html',
  styleUrls: ['./add-venue.component.css']  // Add your styles if needed
})
export class AddVenueComponent implements OnInit {
  venueForm: FormGroup;
  errorMessage: string;
  photoImage:string;
  isEditMode: boolean = false;

  constructor(private fb: FormBuilder, private router: Router, private venueService: VenueService, private route: ActivatedRoute,
    ) { }

  ngOnInit(): void {
    this.initializeForm();
    this.isEditMode = this.route.snapshot.url[1]?.path === 'edit';

    if (this.isEditMode) {
      this.loadVenueData();
    }
  }

  selectedDate: string; // Make sure to use the correct data type for your date

  getTodayDate(): string {
    const today = new Date();
    const month = (today.getMonth() + 1).toString().padStart(2, '0');
    const day = today.getDate().toString().padStart(2, '0');
    const formattedDate = `${today.getFullYear()}-${month}-${day}`;
    return formattedDate;
  }

  loadVenueData(): void {
    const venueId = this.route.snapshot.paramMap.get('id');
    this.venueService.getVenueById(venueId).subscribe(
      (venue) => {
        // Prefill the form with venue data
        this.venueForm.patchValue({
          venueName: venue.VenueName,
          venueImage: this.photoImage,
          venueDescription: venue.VenueDescription,
          venueLocation: venue.VenueLocation,
          venueId: venue.VenueId
        });
      },
      (error) => {
        console.error('Error fetching venue data', error);
      }
    );
  }


  initializeForm(): void {
    this.venueForm = this.fb.group({
      venueName: ['', Validators.required],
      venueImage: ['', Validators.required],
      venueDescription: ['', Validators.required],
      venueLocation: ['', Validators.required],
      venueId: ['']
    });
  }

  goBack(): void {
    // Add logic to navigate back if needed
    this.router.navigate(['/admin/venue/dashboard']);
  }

  onSubmit(): void {
    if (this.venueForm.valid) {
if (this.isEditMode) {
  // Handle updating an existing venue
  const venue = {
    VenueName: this.venueForm.get('venueName').value,
    VenueImageURL: this.photoImage,
    VenueDescription: this.venueForm.get('venueDescription').value,
    VenueLocation: this.venueForm.get('venueLocation').value,
    // Add other properties if needed
    VenueId: this.venueForm.get('venueId').value
  };
console.log(venue)
  this.venueService.updateVenue(venue).subscribe(
    (response) => {
      // Handle success if needed
      console.log('Venue updated successfully', response);
      this.router.navigate(['/admin/venue/dashboard']);
      // Navigate to the desired route after successful addition
    },
    (error) => {
      // Handle error if needed
      console.error('Error updating venue', error);
    }  );
} else {
  const venue = {
    VenueName: this.venueForm.get('venueName').value,
    VenueImageURL: this.photoImage,
    VenueDescription: this.venueForm.get('venueDescription').value,
    VenueLocation: this.venueForm.get('venueLocation').value,
    // Add other properties if needed
  };
console.log(venue)
      // Assuming your service method is named addVenue
      this.venueService.addVenue(venue).subscribe(
        (response) => {
          // Handle success if needed
          console.log('Venue added successfully', response);
          this.venueForm.reset(); // Reset the form
          this.router.navigate(['/admin/venue/dashboard']);
          // Navigate to the desired route after successful addition
        },
        (error) => {
          // Handle error if needed
          console.error('Error adding venue', error);
        }
      ); }   } else {
      this.errorMessage = 'Please fill out all required fields.';
    }
  }

  handleFileChange(event: any): void {
    const file = event.target.files[0];

    if (file) {
      this.convertFileToBase64(file).then(
        (base64String) => {
          this.photoImage=base64String
        },
        (error) => {
          console.error('Error converting file to base64:', error);
          // Handle error appropriately
        }
      );
    }
  }

  convertFileToBase64(file: File): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();

      reader.onload = () => {
        resolve(reader.result as string);
      };

      reader.onerror = (error) => {
        reject(error);
      };

      reader.readAsDataURL(file);
    });
  }

}
