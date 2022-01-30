import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material/material.module';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { PersonsComponent } from './pages/persons/persons.component';
import { AppRoutingModule } from './app-routing.module';
import { PersonsService } from './persons.service';

@NgModule({
  declarations: [
    AppComponent,
    PersonsComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    AppRoutingModule
  ],
  providers: [PersonsService],
  bootstrap: [AppComponent]
})
  export class AppModule { }