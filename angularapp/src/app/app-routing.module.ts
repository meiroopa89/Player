import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';
import { FitnessFormComponent } from './fitness-form/fitness-form.component';
import { FitnessListComponent } from './fitness-list/fitness-list.component';



const routes: Routes = [
  { path: 'addNewFitness', component: FitnessFormComponent },
  { path: 'viewFitness', component: FitnessListComponent },
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
