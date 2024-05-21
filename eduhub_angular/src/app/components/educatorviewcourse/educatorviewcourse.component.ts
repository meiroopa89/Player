import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CourseService } from 'src/app/services/course.service';
import { MaterialService } from 'src/app/services/material.service';

@Component({
  selector: 'app-educatorviewcourse',
  templateUrl: './educatorviewcourse.component.html',
  styleUrls: ['./educatorviewcourse.component.css']
})
export class EducatorviewcourseComponent implements OnInit {

  availableCourses: any[] = [];
  showDeletePopup = false;
  showDeletePopup2 = false;
  showMaterialPopup = false;
  courseToDelete: string | null = null;
  searchValue = '';
  sortValue = 0;
  materialToDelete: number;
  materials: any[] = [];
  page: number = 1;
  limit = 5;
  maxRecords = 1;
  totalPages = 1;
  status: string = '';
  filteredCourses = [];
  searchField = '';
  errorMessage: string = '';
  allCourses: any[] = [];
  currentMaterialIndex :number = 0;
  materialMessage : string = 'No Materials Found';

  constructor(private router: Router, private courseService: CourseService , private materialService : MaterialService) {}

  ngOnInit(): void {
    this.fetchAvailableCourses();
  }

  fetchAvailableCourses() {
    this.courseService.getAllCourses().subscribe(
      (data: any) => {
        this.availableCourses = data;
        this.maxRecords = this.availableCourses.length;
        this.allCourses = data;
        this.totalPages = Math.ceil(this.maxRecords / this.limit);
        console.log('Available courses:', this.availableCourses);
      },
      (error) => {
        console.error('Error fetching courses:', error);
      }
    );
  }

  handleDeleteClick(courseId: string) {
    this.courseToDelete = courseId;
    this.showDeletePopup = true;
  }

  navigateToEditCourse(id: string) {
    this.router.navigate(['/educator/editcourse', id]);
  }

  handleConfirmDelete() {
    if (this.courseToDelete) {
      this.courseService.deleteCourse(this.courseToDelete).subscribe(
        (response) => {
          console.log('Course deleted successfully', response);
          this.closeDeletePopup();
          this.fetchAvailableCourses();
          this.errorMessage = '';
        },
        (error) => {
          console.error('Error deleting course:', error);
          this.errorMessage = error.error.message;
        }
      );
    }
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('userName');
    localStorage.removeItem('userRole');
    this.router.navigate(['/login']);
  }

  closeDeletePopup() {
    this.courseToDelete = null;
    this.showDeletePopup = false;
    this.errorMessage = '';
  }

  updateAvailableCourses(newCourses: any[]) {
    this.availableCourses = newCourses;
  }

  handleSearchChange(searchValue: string): void {
    this.searchField = searchValue;
    if (searchValue) {
      this.availableCourses = this.filterCourses(searchValue);
    } else {
      this.availableCourses = this.allCourses;
    }
  }

  filterCourses(search: string) {
    const searchLower = search.toLowerCase();
    if (searchLower === '') return this.availableCourses;
    return this.availableCourses.filter(
      (course) =>
        course.Title.toLowerCase().includes(searchLower) ||
        course.Description.toLowerCase().includes(searchLower)
    );
  }

navigateToAddMaterial(courseId: string) {
  this.router.navigate(['/educator/addmaterial', courseId]);
}

handleViewMaterialClick(courseId: string) {
  this.materialService.getMaterialsByCourseId(courseId).subscribe(
    (response) => {
      console.log('API Response:', response);
      this.materials = response;
      this.showMaterialPopup = true;
      if (this.materials.length > 0) {
        this.currentMaterialIndex = 0;
      }
    },
    (error) => {
      console.error('Error fetching materials:', error);
      this.errorMessage = 'No materials found';
      this.showMaterialPopup = true;
    }
  );
}

  closeMaterialPopup() {
    this.showMaterialPopup = false;
    this.materials = [];
    this.errorMessage = '';
  }


  nextMaterial() {
  if (this.currentMaterialIndex < this.materials.length - 1) {
    this.currentMaterialIndex++;
  }
}

previousMaterial() {
  if (this.currentMaterialIndex > 0) {
    this.currentMaterialIndex--;
  }
}
confirmDeleteMaterial(materialId: number) {
  this.materialToDelete = materialId;
  this.showDeletePopup2 = true;
}

deleteMaterial() {
  this.materialService.deleteMaterial(this.materialToDelete).subscribe(
    (response) => {
      console.log('Material deleted successfully', response);
      this.materials = this.materials.filter(material => material.MaterialId !== this.materialToDelete);
      if (this.currentMaterialIndex === this.materials.length) {
        this.currentMaterialIndex--;
      }
      this.showDeletePopup2 = false;
      this.errorMessage = '';
    },
    (error) => {
      console.error('Error deleting material:', error);
      this.errorMessage = error.error.message;
    }
  );
}


}

