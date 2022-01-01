import { ToastrService } from 'ngx-toastr';
import { MembersService } from 'src/app/_services/members.service';
import { Member } from './../../_models/member';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css']
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member;

  constructor(
    private memberService: MembersService,
    private toastrService: ToastrService,

  ) { }

  ngOnInit(): void {
  }

  addLike(member: Member) {
    this.memberService.addLike(member.username).subscribe(() => {
      this.toastrService.success("You liked " + member.knownAs);
    },);
  }

}
