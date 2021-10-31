import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../Models/listResponseModel';
import { Category } from '../Models/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  apiURL = 'https://localhost:44324/api/categories/getall';

  constructor(private httpClient: HttpClient) {}

  getCategories(): Observable<ListResponseModel<Category>> {
    return this.httpClient.get<ListResponseModel<Category>>(this.apiURL);
  }
}
