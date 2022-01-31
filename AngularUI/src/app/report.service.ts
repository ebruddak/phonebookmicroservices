

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
  private url  = "http://localhost:5000/services/report/reports"

  public getReports() 
  {
    return  this.httpModule.get<ReportDto[]>(this.url,httpOptions);
        
  }
    public addReport(model : ReportDto){
       const content_ = JSON.stringify(model);
      this.httpModule.post<string>(this.url, content_,httpOptions);
    }

  }
