import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {
  validationErrors: string[] = [];

  constructor(
    @Inject("apiUrl") private apiUrl: string,
    private httpClient: HttpClient,
  ) { }

  ngOnInit(): void {
  }

  get404Error() {
    this.httpClient.get(this.apiUrl + "/bug/not-found").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get400Error() {
    this.httpClient.get(this.apiUrl + "/bug/bad-request").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get500Error() {
    this.httpClient.get(this.apiUrl + "/bug/server-error").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get401Error() {
    this.httpClient.get(this.apiUrl + "/bug/auth").subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  get400ValidationError() {
    this.httpClient.post(this.apiUrl + "/account/register", {}).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
      this.validationErrors = error;
    });
  }
}
