import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from 'src/app/services/event.service'; // Import your event service

@Component({
  selector: 'app-add-event',
  templateUrl: './add-event.component.html',
  styleUrls: ['./add-event.component.css']  // Add your styles
})
export class AddEventComponent implements OnInit {
  eventForm: FormGroup;
  errorMessage: string;
  photoImage: string;
  isEditMode: boolean = false;

  constructor(private fb: FormBuilder, private router: Router, private eventService: EventService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.initializeForm();
    this.isEditMode = this.route.snapshot.url[1]?.path === 'edit';

    if (this.isEditMode) {
      this.loadEventData();
    }
  }

  selectedDate: string; // Make sure to use the correct data type for your date
  dateRangeValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const fromDate = control.get('StartDate')?.value;
    const toDate = control.get('EndDate')?.value;

    if (fromDate && toDate) {
      const fromDateObj = new Date(fromDate);
      const toDateObj = new Date(toDate);

      if (fromDateObj > toDateObj) {
        return { 'dateRangeError': true };
      }
    }

    return null;
  }
  getTodayDate(): string {
    const today = new Date();
    const month = (today.getMonth() + 1).toString().padStart(2, '0');
    const day = today.getDate().toString().padStart(2, '0');
    const formattedDate = `${today.getFullYear()}-${month}-${day}`;
    return formattedDate;
  }

  loadEventData(): void {
    const eventId = this.route.snapshot.paramMap.get('id');
    this.eventService.getEventById(eventId).subscribe(
      (event) => {
        // Prefill the form with event data
        this.eventForm.patchValue({
          EventName: event.EventName,
          EventImageURL: this.photoImage,
          StartDate: event.StartDate,
          EndDate: event.EndDate,
          Description: event.Description,
          EventId: event.EventId
        });
      },
      (error) => {
        console.error('Error fetching event data', error);
      }
    );
  }

  initializeForm(): void {
    this.eventForm = this.fb.group({
      EventName: ['', Validators.required],
      EventImageURL: ['', Validators.required],
      StartDate: ['', Validators.required],
      EndDate: ['', Validators.required],
      Description: ['', Validators.required],
      EventId: ['']
    }, { validators: this.dateRangeValidator });
  }

  goBack(): void {
    // Add logic to navigate back if needed
    this.router.navigate(['/organizer/event/dashboard']);
  }

  onSubmit(): void {
    if (this.eventForm.valid) {
      if (this.isEditMode) {
        // Handle updating an existing event
        const event = {
          EventName: this.eventForm.get('EventName').value,
          EventImageURL: this.photoImage,
          StartDate: this.eventForm.get('StartDate').value,
          EndDate: this.eventForm.get('EndDate').value,
          Description: this.eventForm.get('Description').value,
          EventId: this.eventForm.get('EventId').value
        };

        this.eventService.updateEvent(event).subscribe(
          (response) => {
            console.log('Event updated successfully', response);
            this.router.navigate(['/organizer/event/dashboard']);
          },
          (error) => {
            console.error('Error updating event', error);
          }
        );
      } else {
        const event = {
          EventName: this.eventForm.get('EventName').value,
          EventImageURL: this.photoImage,
          StartDate: this.eventForm.get('StartDate').value,
          EndDate: this.eventForm.get('EndDate').value,
          Description: this.eventForm.get('Description').value
        };

        this.eventService.addEvent(event).subscribe(
          (response) => {
            console.log('Event added successfully', response);
            this.eventForm.reset(); // Reset the form
            this.router.navigate(['/organizer/event/dashboard']);
          },
          (error) => {
            console.error('Error adding event', error);
          }
        );
      }
    } else {
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
