import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EnrollmentService } from 'src/app/services/enrollment.service';

@Component({
  selector: 'app-enrollmentlist',
  templateUrl: './enrollmentlist.component.html',
  styleUrls: ['./enrollmentlist.component.css']
})
export class EnrollmentlistComponent implements OnInit {
  enrollments: any[] = []; // Rename loanRequests to enrollments
  searchValue = '';
  sortValue = 0;
  statusFilter = '-1';
  page = 1;
  pagesize = 2;
  maxPageLength = 0;
  maxRecords = 1;
  expandedRow: number | null = null;
  showModal = false;
  selectedEnrollment: any = null; // Rename selectedLoan to selectedEnrollment

  constructor(private enrollmentService: EnrollmentService, private router: Router) {}
  ngOnInit(): void {
    this.fetchData();
  }

  fetchData(): void {
    this.enrollmentService.getAllEnrollments().subscribe( // Use getAllEnrollments method
      (response) => {
        this.enrollments = response; // Rename loanRequests to enrollments
        this.filteredEnrollments = [...this.enrollments]; // Rename filteredLoans to filteredEnrollments
        console.log('enrollments:', this.enrollments); // Rename loanrequest to enrollments
      },
      (error) => {
        console.error('Error fetching enrollments:', error); // Change loans to enrollments
        // Handle error appropriately
      }
    );
  }
  filteredEnrollments = []; // Rename filteredLoans to filteredEnrollments
  availableEnrollments: any[] = []; // Rename availableLoans to availableEnrollments

  handleSearchChange(event: any): void {
    this.searchValue = event.target.value.toLowerCase();
    this.filteredEnrollments = this.enrollments.filter(enrollment =>
      enrollment.Course.Title.toLowerCase().includes(this.searchValue)
    );
  }

  handleFilterChange(event: any): void {
    this.statusFilter = event.target.value;
    this.filteredEnrollments = this.enrollments.filter(enrollment => {
      if (this.statusFilter === '-1') {
        // If the filter is set to 'All', return all enrollments
        return true;
      } else {
        // Otherwise, return only the enrollments that match the selected status
        return enrollment.Status === this.statusFilter;
      }
    });
  }

  handleApprove(enrollment: any): void {
    enrollment.Status = 'Approved';
    this.updateEnrollmentStatus(enrollment);
  }

  handleReject(enrollment: any): void {
    enrollment.Status = 'Rejected';
    this.updateEnrollmentStatus(enrollment);
  }

  updateEnrollmentStatus(enrollment: any): void {
    this.enrollmentService.updateEnrollmentStatus(enrollment.EnrollmentId, enrollment).subscribe(
      (response) => {
        console.log('Response:', response);
        this.fetchData();
      },
      (error) => {
        console.error('Error updating enrollment status:', error);
        // Handle error appropriately
      }
    );
  }

  handleRowExpand(index: number): void {
    const selected = this.enrollments[index];
    console.log('selected:', selected);
    this.expandedRow = this.expandedRow === index ? null : index;
    this.selectedEnrollment = selected;
    this.showModal = !this.showModal;
  }

  closeEnrollmentDetailsModal() {
    this.showModal = false;
  }

  handlePagination(direction: number): void {
    if (direction === -1 && this.page > 1) {
      this.page -= 1;
    } else if (direction === 1 && this.page < this.maxPageLength) {
      this.page += 1;
    }
    this.fetchData();
  }
}
