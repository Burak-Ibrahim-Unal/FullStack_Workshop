import { MembersService } from 'src/app/_services/members.service';
import { Member } from '../../_models/member';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  member: Member;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private memberService: MembersService,
    private activatedRoute: ActivatedRoute,
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

}
