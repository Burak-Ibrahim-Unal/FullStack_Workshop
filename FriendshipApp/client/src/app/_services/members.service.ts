import { AccountService } from './account.service';
import { UserParams } from './../_models/userParams';
import { PaginatedResult } from './../_models/pagination';
import { Member } from './../_models/member';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from './../../environments/environment';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { User } from '../_models/user';
import { getPaginatedResults, getPaginationHeaders } from './paginationHelper';




@Injectable({
  providedIn: 'root'
})
export class MembersService {
  apiUrl = environment.apiUrl;
  members: Member[] = [];
  memberCache = new Map();
  user: User;
  userParams: UserParams;

  constructor(
    private httpClient: HttpClient,
    private accountService: AccountService,
  ) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
      this.userParams = new UserParams(user);
    });
  }

  getUserParams() {
    return this.userParams;
  }

  setUserParams(params: UserParams) {
    this.userParams = params;
  }

  resetUserParams() {
    this.userParams = new UserParams(this.user);
    return this.userParams;
  }

  getMembers(userParams: UserParams) {
    var response = this.memberCache.get(Object.values(userParams).join("-"));
    if (response) return of(response);

    let params = getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

    params = params.append("minAge", userParams.minAge.toString());
    params = params.append("maxAge", userParams.maxAge.toString());
    params = params.append("gender", userParams.gender);
    params = params.append("orderBy", userParams.orderBy);

    return getPaginatedResults<Member[]>(this.apiUrl + "users", params, this.httpClient).pipe(
      map(response => {
        this.memberCache.set(Object.values(userParams).join("-"), response);
        return response;
      })
    );
  }


  getMemberByName(username: string) {
    // const member = this.members.find(user => user.username === username);
    // if (member !== undefined) return of(member);
    const member = [...this.memberCache.values()]
      .reduce((arr, elem) => arr.concat(elem.result), [])
      .find((member: Member) => member.username === username);
    if (member) return of(member);
    //console.log(member);
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

  addLike(username: string) {
    return this.httpClient.post(this.apiUrl + "like/" + username, {});
  }

  getLikes(predicate: string, pageNumber, pageSize) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append("predicate", predicate);
    return getPaginatedResults<Partial<Member[]>>(this.apiUrl + "like", params, this.httpClient);
  }


}
