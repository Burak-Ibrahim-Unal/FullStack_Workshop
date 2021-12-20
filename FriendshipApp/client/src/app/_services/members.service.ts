import { Member } from './../_models/member';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';




@Injectable({
  providedIn: 'root'
})
export class MembersService {
  apiUrl = environment.apiUrl;
  members: Member[] = [];

  // httpOptions = {
  //   headers: new HttpHeaders({
  //     Authorization: "Bearer " + JSON.parse(localStorage.getItem("user"))?.token
  //   })
  // }

  constructor(
    private httpClient: HttpClient,
  ) { }

  getMembers() { // getMembers(): Observable<Member[]> {
    if (this.members.length > 0) return of(this.members);
    return this.httpClient.get<Member[]>(this.apiUrl + "users");
  }

  getMemberByName(username: string) {
    return this.httpClient.get<Member>(this.apiUrl + "users/" + username);
  }

  getMemberById(id: number) {
    return this.httpClient.get<Member>(this.apiUrl + "users/" + id);
  }

  updateMember(member: Member) {
    return this.httpClient.put(this.apiUrl + "users", member);
  }


}
