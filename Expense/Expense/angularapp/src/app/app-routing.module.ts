import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ExpenseComponent } from './expense/expense.component';
import { HeaderComponent } from './header/header.component';



const routes: Routes = [
  { path: '', redirectTo: '/addNewExpense', pathMatch: 'full' },
  {path: 'header', component: HeaderComponent},
  { path: 'addNewExpense', component: ExpenseComponent },
  { path: 'viewExpenses', component: DashboardComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
