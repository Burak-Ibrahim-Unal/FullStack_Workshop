import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean;

  constructor(
    private accountService: AccountService
  ) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      this.loggedIn = true;
    }, error => {
      console.log(error);
    });
  }

  logout() {
    this.accountService.logout();
    this.loggedIn = false;
  }

  /* !! turns object to boolean */
  getCurrentUser() {
    this.accountService.currentUser$.subscribe(user => {
       this.loggedIn = !!user;
    }, error => {
      console.log(error);
    });
  }

}
