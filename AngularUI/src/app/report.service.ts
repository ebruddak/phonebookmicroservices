

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { map, Observable } from 'rxjs';
import { ReportDto } from './app.types';
const httpOptions = {
  headers: new HttpHeaders({ 
    'Access-Control-Allow-Origin':'*',
    'Content-Type': 'application/json',
    'Accept':'application/json'
  })
};
@Injectable()
export class ReportService{
  
  constructor(private httpModule : HttpClient) { }
  private url  = "http://localhost:5000/services/report"

  public getReports() 
  {
    let url_ = this.url+ "/Reports";
    return  this.httpModule.get<ReportDto[]>(url_,httpOptions);
        
  }
    public addReport(model : ReportDto){
      let url_ = this.url+ "/Reports/AddReport";
      debugger;
       const content_ = JSON.stringify(model);
      this.httpModule.post(url_, content_,httpOptions).subscribe(resonse=>console.log(resonse));
    }

  }
