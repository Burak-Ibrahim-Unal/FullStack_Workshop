import { PaginatedResult } from './../_models/pagination';
import { Member } from './../_models/member';
import { HttpClient, HttpParams } from '@angular/common/http';
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
  paginatedResult: PaginatedResult<Member[]> = new PaginatedResult<Member[]>();

  // httpOptions = {
  //   headers: new HttpHeaders({
  //     Authorization: "Bearer " + JSON.parse(localStorage.getItem("user"))?.token
  //   })
  // }

  constructor(
    private httpClient: HttpClient,
  ) { }

  // getMembers() { // getMembers(): Observable<Member[]> {
  //   if (this.members.length > 0) return of(this.members);
  //   return this.httpClient.get<Member[]>(this.apiUrl + "users").pipe(
  //     map(members => {
  //       this.members = members;
  //       return members;
  //     })
  //   );
  // }

  getMembers(page?: number, itemsPerPage?: number) {
    let params = new HttpParams();

    if (page !== null && itemsPerPage !== null) {
      params = params.append("pageNumber", page.toString());
      params = params.append("pageSize", itemsPerPage.toString());
    }

    return this.httpClient.get<Member[]>(this.apiUrl + "users", { observe: "response", params }).pipe(
      map(response => {
        this.paginatedResult.result = response.body;
        if (response.headers.get("Pagination") !== null) {
          this.paginatedResult.pagination = JSON.parse(response.headers.get("Pagination"));
        }
        return this.paginatedResult;
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
