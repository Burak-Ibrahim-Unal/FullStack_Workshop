import { AccountService } from './../_services/account.service';
import { Component, Input, OnInit, Output, EventEmitter} from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  //@Input() UsersFromHomeComponent: any; //test
  @Output() cancelRegister = new EventEmitter();
  model: any = {};

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {

  }

  register() {
    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
    }, error => {
        console.log(error);
    })
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
