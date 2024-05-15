import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';
import { PhoneFormComponent } from './flight-form/flight-form.component';
import { PhoneListComponent } from './phone-list/phone-list.component';


const routes: Routes = [
  { path: 'addNewPhone', component: PhoneFormComponent },
  { path: 'viewPhones', component: PhoneListComponent },
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
