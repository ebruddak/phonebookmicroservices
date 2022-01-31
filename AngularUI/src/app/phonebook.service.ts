

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
  private url  = "http://localhost:5000/services/person"

  public getPersons() 
  {
    let url_ =this.url+ "/Persons";
    return  this.httpModule.get<PhoneBookItem[]>(url_,httpOptions);
        
  }

  public GetUserInfos(id : string): Observable<any>{
    let url_ =this.url+ "/ContactInfos/GetAllByUserId/";
    var url  = url_ +id
    return this.httpModule.get<ContactInfoDto[]>(url,httpOptions)
    
  }   
    public delete(id : String): Observable<any>{
      
      let url_ = this.url+ "/Persons/";
      var url  = url_ +id
      return this.httpModule.delete(url,httpOptions)
      
    }   
    public deleteContactInfo(id : String): Observable<any>{
      
      let url_ =this.url+  "/ContactInfos/";
      var url  = url_ +id
      return this.httpModule.delete(url,httpOptions)
      
    }      
    public addPerson(model : PhoneBookItem){
       let url_ = this.url+ "/Persons/create";
       const content_ = JSON.stringify(model);
      this.httpModule.post<string>(url_, content_,httpOptions).subscribe(resonse=>console.log(resonse))
    }

    public addContactInfo(model : ContactInfoDto){
       let url_ = this.url+ "/ContactInfos";
       const content_ = JSON.stringify(model);
      this.httpModule.post<string>(url_, content_,httpOptions).subscribe(resonse=>console.log(resonse))
    }
  }
