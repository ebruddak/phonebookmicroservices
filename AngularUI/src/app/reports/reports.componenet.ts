import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ContactInfoDto, PhoneBookItem } from '../app.types';
import { PhoneBookService } from '../phonebook.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

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
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
  }
  addReport(){

  }
  gotoPersons(){
    this.router.navigate(['/persons']);
  }
}
