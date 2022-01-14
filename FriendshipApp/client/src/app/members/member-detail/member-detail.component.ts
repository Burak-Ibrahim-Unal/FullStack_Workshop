import { MessageService } from 'src/app/_services/message.service';
import { MembersService } from 'src/app/_services/members.service';
import { Member } from '../../_models/member';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { Message } from 'src/app/_models/message';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  member: Member;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];
  @ViewChild("memberTabs") memberTabs: TabsetComponent;
  activeTab: TabDirective;
  messages: Message[] = [];

  constructor(
    private memberService: MembersService,
    private activatedRoute: ActivatedRoute,
    private messageService: MessageService,
  ) { }

  ngOnInit(): void {
    this.loadMemberByUsername();
    this.galleryOptions = [
      {
        width: '600px',
        height: '600px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        imagePercent: 100,
        preview: false

      },
    ]


  }

  getImages(): NgxGalleryImage[] {
    const imageUrls = [];
    for (let i = 0; i < this.member.photos.length; i++) {
      imageUrls.push({
        small: this.member.photos[i]?.url,
        medium: this.member.photos[i]?.url,
        big: this.member.photos[i]?.url
      })
    }
    return imageUrls;
  }

  // loadMemberById() {
  //   this.memberService.getMemberById(this.activatedRoute.snapshot.paramMap.get("id"));
  // }

  loadMemberByUsername() {
    this.memberService.getMemberByName(this.activatedRoute.snapshot.paramMap.get('username')).subscribe(member => {
      this.member = member;
      this.galleryImages = this.getImages();
    });
  }

  loadMessages() {
    this.messageService.getMessageThread(this.member.username).subscribe(messages => {
      this.messages = messages;
    });
  }


  onTabActivated(data: TabDirective) {
    this.activeTab = data;
    if (this.activeTab.heading === "Messages" && this.messages.length === 0) {
      this.loadMessages();
    }
  }

}
