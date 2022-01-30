import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { PhoneBookItem } from '../app.types';
import { PhoneBookService } from '../phonebook.service';

@Component({
  selector: 'app-phone-number-form',
  templateUrl: './phone-number-form.component.html',
  styleUrls: ['./phone-number-form.component.css']
})
export class PhoneNumberFormComponent implements OnInit {

  newPersonForm!: FormGroup;
  constructor(
    private formBuilder: FormBuilder,
    private phoneBookService: PhoneBookService,
    public dialogRef: MatDialogRef<PhoneNumberFormComponent>,
  ) { }

  ngOnInit(): void {

    this.newPersonForm = this.formBuilder.group({
      name: [''],
      surname: [''],
      company: [''],
    })
  }

  savePerson() {
    debugger;
    const person: PhoneBookItem = {
      name: this.newPersonForm.get('name')?.value,
      surname: this.newPersonForm.get('surname')?.value,
      company: this.newPersonForm.get('company')?.value
    }
debugger;
     this.phoneBookService.addPerson(person);
    this.dialogRef.close();

  }

}
