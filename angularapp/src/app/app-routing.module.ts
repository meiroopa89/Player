import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';
import { BookFormComponent } from './player-form/book-form.component';
import { BookListComponent } from './book-list/book-list.component';



const routes: Routes = [
  { path: 'addNewBook', component: BookFormComponent },
  { path: 'viewBooks', component: BookListComponent },
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
