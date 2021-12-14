import { AccountService } from './_services/account.service';
import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'FriendShip App';
  users: any;

  constructor(
    private httpClient: HttpClient,
    @Inject("apiUrl") private apiUrl: string,
    private accountService: AccountService
  ) {

  }

  ngOnInit(): void {
    this.getUsers();
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem("user"));
    this.accountService.setCurrentUser(user);
  }

  getUsers(): void {
    this.httpClient.get(this.apiUrl + "/users").subscribe(response => {
      console.log(response);
      this.users = response;
    }, error => {
      console.log(error);
    });
  }
}
