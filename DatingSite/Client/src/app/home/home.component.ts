import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode: boolean = false;
  users: any;

  constructor(
    @Inject("baseUrl") private baseUrl: string,
    private httpClient: HttpClient,

  ) { }

  ngOnInit(): void {
    this.getUsers();
    console.log(this.users);
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  getUsers() {
    this.httpClient.get(this.baseUrl + "users").subscribe(users => {
      this.users = users
    });
  }
}
