import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};

  constructor() { }

  ngOnInit(): void {

  }

  login() {
    console.log(this.model);
  }


  // receive Data, () = Send Data
}
