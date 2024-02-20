import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Event } from 'src/app/models/event.model'; // Make sure to import the correct model
import { EventService } from 'src/app/services/event.service'; // Assuming you have a service for event operations

@Component({
  selector: 'app-organizer-event-dashboard',
  templateUrl: './organizer-event-dashboard.component.html',
  styleUrls: ['./organizer-event-dashboard.component.css']
})
export class OrganizerEventDashboardComponent implements OnInit {

  showDeletePopup = false;
  selectedEvent: Event;
  events: Event[] = [];

  constructor(
    private router: Router,
    private eventService: EventService // Make sure to inject the correct service
  ) {}

  ngOnInit(): void {
    this.getAllEvents();
  }

  navigateToAddEvent() {
    this.router.navigate(['organizer/add/event']);
  }

  navigateToEditEvent(eventId: number) {
    console.log('Event to be edited', eventId);
    this.router.navigate(['/organizer/edit/event', eventId]); // Assuming you have a property named eventId in your model
  }

  getAllEvents() {
    this.eventService.getAllEvents().subscribe(
      (data) => {
        console.log(data);
        this.events = data;
      },
      (error) => {
        console.error('Error retrieving events', error);
      }
    );
  }

  deleteEvent(eventId: number) {
    console.log(eventId)
    this.eventService.deleteEvent(eventId).subscribe(
      (response) => {
        console.log('Event deleted successfully', response);
        this.getAllEvents();
      },
      (error) => {
        console.error('Error deleting event', error);
      }
    );
  }
}
