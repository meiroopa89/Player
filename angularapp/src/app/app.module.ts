import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './header/header.component';
import { DeleteConfirmComponent } from './delete-confirm/delete-confirm.component';
import { BookFormComponent } from './player-form/player-form.component';
import { BookListComponent } from './player-list/player-list.component';




@NgModule({
  declarations: [
    AppComponent,
    BookFormComponent,
    HeaderComponent,
    BookListComponent,
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
