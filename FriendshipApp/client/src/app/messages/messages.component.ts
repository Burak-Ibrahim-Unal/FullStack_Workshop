import { Pagination } from './../_models/pagination';
import { Component, OnInit } from '@angular/core';
import { Message } from '../_models/message';
import { MessageService } from '../_services/message.service';


@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {
  messages: Message[];
  pagination: Pagination;
  container = "Unread";
  pageNumber = 1;
  pageSize = 6;
  messageFrom = "From";
  messageTo = "To";
  messageSent = "Sent";
  messageReceived = "Received";

  constructor(
    private messageService: MessageService,
  ) { }

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages() {
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages = response.result;
      this.pagination = response.pagination;
      console.log(this.messages);
    });
  }

  pageChanged(event: any) {
    if (this.pageNumber !== event.page) {
      this.pageNumber = event.page;
      this.loadMessages();
    }

  }

}
