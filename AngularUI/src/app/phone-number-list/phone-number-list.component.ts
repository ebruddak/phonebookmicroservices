import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ContactInfoDto, PhoneBookItem } from '../app.types';
import { ContactInfoFormComponent } from '../contact-info-form/contact-info-form.component';
import { PhoneNumberFormComponent } from '../phone-number-form/phone-number-form.component';
import { PhoneBookService } from '../phonebook.service';

@Component({
  selector: 'app-phone-number-list',
  templateUrl: './phone-number-list.component.html',
  styleUrls: ['./phone-number-list.component.css']
})
export class PhoneNumberListComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['avatar', 'name','surname','company','deleteEmployee','addInfo'];
  dataSourceInfo: any;
  displayedColumnsInfo: string[] = ['phoneNumber','email','address', 'deleteInfo'];
  selectedPerson!: PhoneBookItem;
  selectedContactInfo!: ContactInfoDto;
  phoneBookFilterForm!: FormGroup;

  constructor(
    private matDialog: MatDialog,
    private phoneBookService: PhoneBookService,
    private formBuilder: FormBuilder

  ) { }

  ngOnInit(): void {


this.refreshData();
  
  }
  savePerson() {
    this.matDialog.open(PhoneNumberFormComponent, {
      width: '550px',

    }).afterClosed().subscribe((res) => {
      this.refreshData();

    })
  }
  deletePerson() {
    this.phoneBookService.delete(this.selectedPerson.uuid).subscribe(a=> {
     this.dataSourceInfo =a;  
     this.refreshData();

  });

}

deleteContactInfo() {
  debugger
  this.phoneBookService.deleteContactInfo(this.selectedContactInfo.id);
  this.phoneBookService.GetUserInfos(this.selectedPerson.uuid).subscribe(rs=> {
    this.dataSourceInfo =rs;   
  });
  

}
  addPersonInfo() {
   
    this.matDialog.open(ContactInfoFormComponent, {
      width: '550px',
      data       : {
       
            personID: this.selectedPerson.uuid

    },
    }).afterClosed().subscribe((res) => {
    })

  }
  selectPerson(person: any) {
    this.selectedPerson = person;
    debugger;
    this.phoneBookService.GetUserInfos(person.uuid).subscribe(a=> {
     this.dataSourceInfo =a;   
 });


  }
  selectContactInfo(contactInfo: any) {
    this.selectedContactInfo = contactInfo;
  }
  search(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  refreshData() {
    this.phoneBookService.getPersons().subscribe(a=> {
      this.dataSource =a;  
  });

    this.phoneBookFilterForm = this.formBuilder.group({
      search: ['']
    })

  }


}
