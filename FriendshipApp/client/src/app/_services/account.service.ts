import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(
    @Inject("apiUrl") private apiUrl: string,
    private httpClient: HttpClient,
  ) { }

  login(model: any) {
    this.httpClient.post(this.apiUrl + "/account/login", model);
  }


}
