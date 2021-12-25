import { ToastrService } from 'ngx-toastr';
import { AccountService } from './../_services/account.service';
import { User } from './../_models/user';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  // @Input() usersFromHome: any;
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;

  constructor(
    private accountService: AccountService,
    private toastrService: ToastrService,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = this.formBuilder.group({
      username: ["", Validators.required],
      password: ["", [Validators.required, Validators.minLength(4), Validators.maxLength(8)]],
      confirmPassword: ["", [Validators.required, this.matchPasswords("password")]]
    });
    this.registerForm.controls.password.valueChanges.subscribe(() => {
      this.registerForm.controls.confirmPassword.updateValueAndValidity();
    });
  }


  matchPasswords(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value
        ? null
        : { isMatching: true }
    }
  }



  register() {
    console.log(this.registerForm.value);
    // Old Way
    //   this.accountService.register(this.model).subscribe(repsonse => {
    //     this.toastrService.success("Register is success " + this.model.username, "Register Successful");
    //     console.log(repsonse);
    //     this.cancel();
    //   }, error => {
    //     this.toastrService.error(error.error + this.model.username, "Register Failed");
    //     console.log(error);
    //   });
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
