import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { getPaginatedResults, getPaginationHeaders } from './paginationHelper';
import { Message } from '../_models/message';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  apiUrl = environment.apiUrl;

  constructor(
    private httpClient: HttpClient,

  ) { }


  getMessages(pageNumber, pageSize, container) {
    let params = getPaginationHeaders(pageNumber, pageSize);
    params = params.append("Container", container);
    return getPaginatedResults<Message[]>(this.apiUrl + "messages", params, this.httpClient);

  }


  getMessageThread(username: string) {
    return this.httpClient.get<Message[]>(this.apiUrl + "messages/thread/" + username);
  }


  sendMessage(username: string, content: string) {
    return this.httpClient.post<Message>(this.apiUrl + "messages", { recipientUsername: username, content })
  }

  deleteMessage(id: number) {
    return this.httpClient.delete(this.apiUrl + "messages/" + id);
  }

}
