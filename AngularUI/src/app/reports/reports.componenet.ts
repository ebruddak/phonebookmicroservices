import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { ContactInfoDto, PhoneBookItem,ReportDto } from '../app.types';
import { ReportService } from '../report.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {

  dataSource: any;
  displayedColumns: string[] = [ 'requestTime','createdTime','reportUrl','status'];

  constructor(
    private matDialog: MatDialog,
    private reportService: ReportService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
  this.getReports();
  }
  addReport(){
    const report: ReportDto = {
        reportUrl: "",
        status: false,
        requestTime: new Date(),
        reportItems:[]
      }
    this.reportService.addReport(report);
    this.getReports();

  }
  gotoPersons(){
    this.router.navigate(['/persons']);
  }
  getReports(){
    this.reportService.getReports().subscribe(a=> {
      this.dataSource =a;  
  });
  }
}
