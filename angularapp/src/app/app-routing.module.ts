import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';
import { FlightFormComponent } from './flight-form/flight-form.component';
import { FlightListComponent } from './flight-list/flight-list.component';


const routes: Routes = [
  { path: 'addNewFlight', component: FlightFormComponent },
  { path: 'viewFlights', component: FlightListComponent },
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
