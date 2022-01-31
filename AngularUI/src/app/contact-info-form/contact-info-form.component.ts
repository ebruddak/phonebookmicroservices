import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ContactInfoDto, PhoneBookItem } from '../app.types';
import { PhoneBookService } from '../phonebook.service';

@Component({
  selector: 'app-contact-info-form',
  templateUrl: './contact-info-form.component.html',
  styleUrls: ['./contact-info-form.component.css']
})
export class ContactInfoFormComponent implements OnInit {

  newContactInfoForm!: FormGroup;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: ContactInfoDto ,
    private formBuilder: FormBuilder,
    private phoneBookService: PhoneBookService,
    public dialogRef: MatDialogRef<ContactInfoFormComponent>,
  ) { }

  ngOnInit(): void {
    this.newContactInfoForm = this.formBuilder.group({
      uuid: [''],
      personId:[''],
      address: [''],
      phoneNumber: [''],
      email: [''],
      id: [''],
      content: [''],
    })
  }

  saveContent() {
    const contactInfo: ContactInfoDto = {
   
      type: {
        address: this.newContactInfoForm.get('address')?.value,
        phoneNumber: this.newContactInfoForm.get('phoneNumber')?.value,
        email: this.newContactInfoForm.get('email')?.value
      },
      personID:this.data.personID,
      id: this.newContactInfoForm.get('id')?.value,
      content: this.newContactInfoForm.get('content')?.value,
    }
     this.phoneBookService.addContactInfo(contactInfo);
    this.dialogRef.close();

  }

}
