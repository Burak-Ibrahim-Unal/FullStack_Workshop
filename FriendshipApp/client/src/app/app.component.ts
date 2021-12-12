import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

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
  ) {

  }

  ngOnInit(): void {
    this.getUsers();
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
