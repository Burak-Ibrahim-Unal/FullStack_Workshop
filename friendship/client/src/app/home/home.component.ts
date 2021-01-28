import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  //users: any; //test

  // constructor(private http:HttpClient) { } //test
  /**
   *
   */
  constructor() { }

  ngOnInit(): void {
    //this.getUsers(); //test
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }
  /*//test
  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe(users => this.users=users);
  }*/

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
