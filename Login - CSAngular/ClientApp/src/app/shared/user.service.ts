import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  body={
    Name:'',
    Email:'',
    Cpf:'',
    Phone:'',
    Address:'',
    Password:''
  };

  loginBody={
    UserName:'',
    Password: ''
}

  resetForm(){
    this.body.Email = ''
    this.body.Password = ''
    this.body.Cpf = ''
    this.body.Address = ''
    this.body.Phone = ''
  }

  readonly BaseURI = 'https://localhost:7024/api'
   register() {

     return this.http.post(this.BaseURI + '/Register', this.body);
  }


    login() {
      return this.http.post(this.BaseURI + '/Login', this.loginBody);
    }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/UserProfile');
  }

  constructor(private http: HttpClient) { }


}
