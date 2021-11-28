import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {


  constructor(
    @Inject("baseUrl") private baseUrl: string,
    private httpClient: HttpClient,
  ) { }

  login(model: any) {
    return this.httpClient.post(this.baseUrl + "account/login", model);
  }
}
