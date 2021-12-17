import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.css']
})
export class ServerErrorComponent implements OnInit {
  Error: any;

  constructor(private router: Router) {
    const navi = this.router.getCurrentNavigation();
    this.Error = navi?.extras?.state?.error;
  }

  ngOnInit(): void {
  }

}
