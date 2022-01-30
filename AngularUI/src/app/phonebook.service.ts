

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { map, Observable } from 'rxjs';
import { ContactInfoDto, PhoneBookItem } from './app.types';
const httpOptions = {
  headers: new HttpHeaders({ 
    'Access-Control-Allow-Origin':'*',
    'Content-Type': 'application/json',
    'Accept':'application/json'
  })
};
@Injectable()
export class PhoneBookService{
  
  constructor(private httpModule : HttpClient) { }
  private url  = "http://localhost:5011/api/Persons"

  public getPersons() 
  {
 
    return  this.httpModule.get<PhoneBookItem[]>(this.url,httpOptions);
        
  }

  public GetUserInfos(id : string): Observable<any>{
    debugger;
    let url_ = "http://localhost:5011/api/ContactInfos/GetAllByUserId/";
    var url  = url_ +id
    return this.httpModule.get<ContactInfoDto[]>(url,httpOptions)
    
  }   
    public delete(id : String): Observable<any>{
      
      let url_ = "http://localhost:5011/api/Persons/";
      var url  = url_ +id
      return this.httpModule.delete(url,httpOptions)
      
    }   
    public deleteContactInfo(id : String): Observable<any>{
      
      let url_ = "http://localhost:5011/api/ContactInfos/";
      var url  = url_ +id
      return this.httpModule.delete(url,httpOptions)
      
    }      
    public addPerson(model : PhoneBookItem){
      debugger
       let url_ = "http://localhost:5011/api/Persons/create";
       const content_ = JSON.stringify(model);
      this.httpModule.post<string>(url_, content_,httpOptions).subscribe(resonse=>console.log(resonse))
    }

    public addContactInfo(model : ContactInfoDto){
      debugger
       let url_ = "http://localhost:5011/api/ContactInfos";
       const content_ = JSON.stringify(model);
      this.httpModule.post<string>(url_, content_,httpOptions).subscribe(resonse=>console.log(resonse))
    }
  }
