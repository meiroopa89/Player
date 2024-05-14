import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CarFormComponent } from './phone-form/phone-form.component';
import { CarListComponent } from './phone-list/phone-list.component';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';


const routes: Routes = [
  { path: 'addNewCar', component: CarFormComponent },
  { path: 'viewCars', component: CarListComponent },
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
