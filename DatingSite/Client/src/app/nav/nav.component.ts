import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastrService: ToastrService,
  ) { }

  ngOnInit(): void {

  }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl("/members");
      this.toastrService.success("Login is successful","Logging");
      console.log(response);
    }, error => {
      console.log(error);
      this.toastrService.error(error.error,"Logging");
    });
  }

  logout() {
    this.router.navigateByUrl("/");
    this.accountService.logout();
    this.toastrService.warning("Log out is successful","Log out",);
  }
}
