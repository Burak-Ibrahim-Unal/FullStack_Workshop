import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {

  validatinErrors: String[] = [];

  constructor(
    @Inject("baseUrl") private baseUrl: string,
    private httpClient: HttpClient,
  ) { }

  ngOnInit(): void {

  }

  get404Error() {
    this.httpClient.get(this.baseUrl + "bug/not-found").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get400Error() {
    this.httpClient.get(this.baseUrl + "bug/bad-request").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get500Error() {
    this.httpClient.get(this.baseUrl + "bug/server-error").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get401Error() {
    this.httpClient.get(this.baseUrl + "bug/auth").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get400ValidationError() {
    this.httpClient.get(this.baseUrl + "account/register", {}).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.validatinErrors = error;
    });
  }

}
