import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PhoneNumberListComponent } from './phone-number-list/phone-number-list.component';
import { ReportsComponent } from './reports/reports.componenet';

const routes: Routes = [
  {
    path: '',
    component: PhoneNumberListComponent
  },
  { path: 'persons', component: PhoneNumberListComponent },
  { path: 'reports', component: ReportsComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
