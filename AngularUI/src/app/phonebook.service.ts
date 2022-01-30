

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { map, Observable } from 'rxjs';
import { PhoneBookItem } from './app.types';
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
    public delete(id : number): Observable<any>{
      
      var url  = this.url +id
      return this.httpModule.delete<PhoneBookItem>(url)
      
    }      
    public addPerson(model : PhoneBookItem){
      debugger
       let url_ = "http://localhost:5011/api/Persons/create";
       const content_ = JSON.stringify(model);
      this.httpModule.post<string>(url_, content_,httpOptions).subscribe(resonse=>console.log(resonse))



    }


  }
