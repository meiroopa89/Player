import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ErrorComponent } from './components/error/error.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';

import { HomeComponent } from './components/home/home.component';
import { AuthGuard } from './components/authguard/auth.guard';


import { AdminviewfeedbackComponent } from './components/adminviewfeedback/adminviewfeedback.component';
import { UserviewfeedbackComponent } from './components/userviewfeedback/userviewfeedback.component';
import { UseraddfeedbackComponent } from './components/useraddfeedback/useraddfeedback.component';
import { EducatoraddcourseComponent } from './components/educatoraddcourse/educatoraddcourse.component';
import { EducatorviewcourseComponent } from './components/educatorviewcourse/educatorviewcourse.component';
import { EducatoreditcourseComponent } from './components/educatoreditcourse/educatoreditcourse.component';
import { EducatoraddmeterialComponent } from './components/educatoraddmeterial/educatoraddmeterial.component';
import { EnrollmentlistComponent } from './components/enrollmentlist/enrollmentlist.component';
import { StudentviewcourseComponent } from './components/studentviewcourse/studentviewcourse.component';
import { MycourseComponent } from './components/mycourse/mycourse.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent },
  {path: 'signup', component: RegistrationComponent },
  {path: 'error', component: ErrorComponent },
  {path :'admin/view/feedback', component: AdminviewfeedbackComponent, canActivate: [AuthGuard]},
  {path :'user/view/feedback', component: UserviewfeedbackComponent, canActivate: [AuthGuard]},
  {path :'user/add/feedback', component: UseraddfeedbackComponent, canActivate: [AuthGuard]},

  {path: 'educator/add/course', component: EducatoraddcourseComponent, canActivate: [AuthGuard]},
  {path: 'educator/view/course', component: EducatorviewcourseComponent, canActivate: [AuthGuard]},
  {path: 'educator/editcourse/:id', component: EducatoreditcourseComponent , canActivate: [AuthGuard]},
  {path: 'educator/addmaterial/:courseId', component: EducatoraddmeterialComponent , canActivate: [AuthGuard]},
  {path: 'educator/view/requestedenroll', component: EnrollmentlistComponent, canActivate: [AuthGuard]},
  {path: 'student/view/course', component: StudentviewcourseComponent, canActivate: [AuthGuard]},
  {path: 'student/view/mycourse', component: MycourseComponent, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '/error' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
