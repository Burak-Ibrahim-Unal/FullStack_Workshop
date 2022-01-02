import { Pagination } from './../_models/pagination';
import { MembersService } from 'src/app/_services/members.service';
import { Member } from './../_models/member';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  members: Partial<Member[]>;
  predicate = "liked";
  pagenNumber = 1;
  pageSize = 6;
  pagination: Pagination;


  constructor(
    private memberService: MembersService,
  ) { }

  ngOnInit(): void {
    this.loadLikes();
  }


  loadLikes() {
    this.memberService.getLikes(this.predicate, this.pagenNumber, this.pageSize).subscribe(response => {
      this.members = response.result;
      this.pagination = response.pagination;

    });
  }

  pageChanged(event: any) {
    this.pagenNumber = event.page;
    this.loadLikes();
  }

}
