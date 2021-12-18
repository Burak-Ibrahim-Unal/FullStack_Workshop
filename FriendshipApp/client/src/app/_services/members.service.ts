import { Observable } from 'rxjs';
import { Member } from './../_models/member';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';


const httpOptions = {
  headers: new HttpHeaders({
    Authorization: "Bearer " + JSON.parse(localStorage.getItem("user")).token
  })
}

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  apiUrl = environment.apiUrl;

  constructor(
    private httpClient: HttpClient,
  ) { }

  getMembers() { // getMembers(): Observable<Member[]> {
    return this.httpClient.get<Member[]>(this.apiUrl + "users", httpOptions);
  }

  getMemberByName(username: string) {
    return this.httpClient.get<Member>(this.apiUrl + "users/" + username, httpOptions);
  }

  getMemberById(id: number) {
    return this.httpClient.get<Member>(this.apiUrl + "users/" + id, httpOptions);
  }

}
