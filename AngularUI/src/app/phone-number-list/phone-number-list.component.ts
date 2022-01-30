import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { PhoneBookItem } from '../app.types';
import { PhoneNumberFormComponent } from '../phone-number-form/phone-number-form.component';
import { PhoneBookService } from '../phonebook.service';

@Component({
  selector: 'app-phone-number-list',
  templateUrl: './phone-number-list.component.html',
  styleUrls: ['./phone-number-list.component.css']
})
export class PhoneNumberListComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = ['avatar', 'name'];
  selectedPerson!: PhoneBookItem;
  phoneBookFilterForm!: FormGroup;

  constructor(
    private matDialog: MatDialog,
    private phoneBookService: PhoneBookService,
    private formBuilder: FormBuilder

  ) { }

  ngOnInit(): void {


     this.phoneBookService.getPersons().subscribe(a=> {
       debugger;
      this.dataSource =a;
      
  });
    this.phoneBookFilterForm = this.formBuilder.group({
      search: ['']
    })

  
  }
  savePerson() {
    this.matDialog.open(PhoneNumberFormComponent, {
      width: '550px'
    }).afterClosed().subscribe((res) => {
    })
  }
  selectPerson(person: any) {
    this.selectedPerson = person;
  }

  search(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

}
