import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctorFormComponent } from './doctor-form/doctor-form.component';
import { DoctorListComponent } from './doctor-list/doctor-list.component';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';


const routes: Routes = [
  { path: 'addNewDoctor', component: DoctorFormComponent },
  { path: 'viewDoctors', component: DoctorListComponent },
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
