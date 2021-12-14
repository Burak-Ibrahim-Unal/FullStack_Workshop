import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  users: any;

  constructor(
    private httpClient: HttpClient,
    @Inject("apiUrl") private apiUrl: string,
  ) { }

  ngOnInit(): void {
    // this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;

  }


  getUsers() {
    this.httpClient.get(this.apiUrl + "/users").subscribe(users => this.users = users);

  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
