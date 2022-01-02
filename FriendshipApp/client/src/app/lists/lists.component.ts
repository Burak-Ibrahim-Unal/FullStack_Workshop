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
  predicate = "";


  constructor(
    private memberService: MembersService,
  ) { }

  ngOnInit(): void {
  }


  loadLikes() {
    this.memberService.getLikes(this.predicate).subscribe(response => {
      this.members = response;
    });
  }

}
