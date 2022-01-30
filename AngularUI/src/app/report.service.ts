

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
  private url  = "http://localhost:5012/api/Reports"

  public getReports() 
  {
    return  this.httpModule.get<ReportDto[]>(this.url,httpOptions);
        
  }

    public addReport(model : ReportDto){
        debugger;
       let url_ = "http://localhost:5012/api/Reports";
       const content_ = JSON.stringify(model);
      this.httpModule.post<string>(url_, content_,httpOptions);
    }

  }
