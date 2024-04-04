import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReceipeFormComponentComponent } from './receipe-form-component/receipe-form-component.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ReceipeServiceComponent } from './receipe-service/receipe-service.component';

@NgModule({
  declarations: [
    AppComponent,
    ReceipeFormComponentComponent,
    ReceipeServiceComponent
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
