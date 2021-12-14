import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};

  constructor(
    public accountService: AccountService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.accountService.currentUser$;
  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl("/members");
      // console.log(response);
    }, error => {
      console.log(error);
    });
  }


  logout() {
    this.accountService.logout();
    this.router.navigateByUrl("/");
  }

  // receive Data, () = Send Data
}
