import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {
  MatButtonModule
} from '@angular/material/button';
import {
  MatIconModule
} from '@angular/material/icon';

import { AppComponent } from './app.component';
import { PersonsComponent } from './pages/persons/persons.component';

import { PersonsService } from './persons.service';

const routes: Routes = [
  { path: '', component: PersonsComponent },
  { path: 'persons', component: PersonsComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    PersonsComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(routes),
    MatButtonModule,
    MatIconModule
  ],
  providers: [PersonsService],
  bootstrap: [AppComponent]
})
export class AppModule { }