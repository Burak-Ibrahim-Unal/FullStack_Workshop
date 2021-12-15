import { ToastrService } from 'ngx-toastr';
import { AccountService } from './../_services/account.service';
import { User } from './../_models/user';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() usersFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(
    private accountService: AccountService,
    private toastrService: ToastrService,
  ) { }

  ngOnInit(): void {
  }


  register() {
    this.accountService.register(this.model).subscribe(repsonse => {
      this.toastrService.success("Register is success " + this.model.username,"Register Successful");
      console.log(repsonse);
      this.cancel();
    }, error => {
      this.toastrService.error(error.error + this.model.username,"Register Failed");
      console.log(error);
    });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
