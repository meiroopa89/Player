import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';
import { PhoneFormComponent } from './flight-form/flight-form.component';
import { PhoneListComponent } from './phone-list/phone-list.component';




@NgModule({
  declarations: [
    AppComponent,
    PhoneFormComponent,
    HeaderComponent,
    PhoneListComponent,
    DeleteConfirmComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
