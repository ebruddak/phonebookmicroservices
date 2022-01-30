import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PhoneNumberListComponent } from './phone-number-list/phone-number-list.component';

const routes: Routes = [
  {
    path: '',
    component: PhoneNumberListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
