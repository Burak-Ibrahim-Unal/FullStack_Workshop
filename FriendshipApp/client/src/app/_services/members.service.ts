import { Member } from './../_models/member';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';




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
    return this.httpClient.get<Member[]>(this.apiUrl + "users").pipe(
      map(members => {
        this.members = members;
        return members;
      })
    );
  }

  getMemberByName(username: string) {
    const member = this.members.find(user => user.username === username);
    if (member !== undefined) return of(member);
    return this.httpClient.get<Member>(this.apiUrl + "users/" + username);
  }

  getMemberById(id: number) {
    const member = this.members.find(user => user.id === id);
    if (member !== undefined) return of(member);
    return this.httpClient.get<Member>(this.apiUrl + "users/" + id);
  }

  updateMember(member: Member) {
    return this.httpClient.put(this.apiUrl + "users", member).pipe(
      map(() => {
        const index = this.members.indexOf(member);
        this.members[index] = member;
      })
    );
  }

  setMainPhoto(photoId: number) {
    return this.httpClient.put(this.apiUrl + "users/set-main-photo/" + photoId, {});
  }


  deletePhoto(photoId: number) {
    return this.httpClient.delete(this.apiUrl + "users/delete-photo/" + photoId);
  }

}
