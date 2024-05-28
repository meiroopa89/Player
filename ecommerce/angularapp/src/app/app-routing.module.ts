import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { ViewProductComponent } from './components/view-product/view-product.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { DeleteConfirmComponent } from './components/delete-confirm/delete-confirm.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: RegistrationComponent },
  {path: 'admin/addProducts', component: AddProductComponent },
  {path: 'user/viewProducts', component: ViewProductComponent},
  {path: 'admin/viewProducts', component: ViewProductComponent},
  // { path: 'edit-product/:id', component: EditProductComponent },
  {path: 'edit-product', component: EditProductComponent},
  { path: 'confirmDelete/:id', component: DeleteConfirmComponent},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
