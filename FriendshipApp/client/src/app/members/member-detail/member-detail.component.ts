import { MembersService } from 'src/app/_services/members.service';
import { Member } from './../../_models/member';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  member: Member;

  constructor(
    private memberService: MembersService,
    private activatedRoute: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.loadMemberByUsername();
  }


  // loadMemberById() {
  //   this.memberService.getMemberById(this.activatedRoute.snapshot.paramMap.get("id"));
  // }

  loadMemberByUsername() {
    this.memberService.getMemberByName(this.activatedRoute.snapshot.paramMap.get('username')).subscribe(member => {
      this.member = member;
    });
  }

}
