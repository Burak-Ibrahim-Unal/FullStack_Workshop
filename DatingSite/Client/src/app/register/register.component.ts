import { Component, Input, OnInit } from '@angular/core';
import { User } from '../_models/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Input() usersFromHomeComponent: any;
  model: any = {};


  constructor() { }

  ngOnInit(): void {

  }

  register() {
    console.log(this.model);
  }

  cancel() {
    console.log("canceled");
  }

}
