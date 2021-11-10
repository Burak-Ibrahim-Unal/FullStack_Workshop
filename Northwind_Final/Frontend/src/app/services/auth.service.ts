import { TokenModel } from './../Models/tokenModel';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from './../Models/loginModel';
import { Injectable } from '@angular/core';
import { SingleResponseModel } from '../Models/singleResponseModel';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    apiURL = 'https://localhost:44324/api/auth/';
    constructor(private httpClient: HttpClient) { }

    login(loginModel: LoginModel) {
        return this.httpClient.post<SingleResponseModel<TokenModel>>(this.apiURL + "login", loginModel);
    }

    isAuthenticated() {
        if (localStorage.getItem("token")) {
            return true;
        } else {
            return false;
        }
    }
}
