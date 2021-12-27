import { UserParams } from './../_models/userParams';
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

  constructor(
    private httpClient: HttpClient,
  ) { }


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


  getMembers(userParams: UserParams) {
    let params = this.getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

    params = params.append("minAge", userParams.minAge.toString());
    params = params.append("maxAge", userParams.maxAge.toString());
    params = params.append("gender", userParams.gender);

    return this.getPaginatedResults<Member[]>(this.apiUrl + "users", params);
  }


  setMainPhoto(photoId: number) {
    return this.httpClient.put(this.apiUrl + "users/set-main-photo/" + photoId, {});
  }


  deletePhoto(photoId: number) {
    return this.httpClient.delete(this.apiUrl + "users/delete-photo/" + photoId);
  }

  private getPaginatedResults<T>(url, params) {
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
    return this.httpClient.get<T>(url, { observe: "response", params }).pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get("Pagination") !== null) {
          paginatedResult.pagination = JSON.parse(response.headers.get("Pagination"));
        }
        return paginatedResult;
      })
    );
  }

  private getPaginationHeaders(pageNumber: number, pageSize: number) {
    let params = new HttpParams();
    params = params.append("pageNumber", pageNumber.toString());
    params = params.append("pageSize", pageSize.toString());

    return params;

  }
}
