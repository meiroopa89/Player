import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookFormComponent } from './book-form/book-form.component';
import { BookListComponent } from './book-list/book-list.component';
import { HeaderComponent } from './header/header.component';

const routes: Routes = [
  { path: 'addNewBook', component: BookFormComponent },
  { path: 'viewBooks', component: BookListComponent },
  {path: 'header', component: HeaderComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
