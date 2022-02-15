import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { environment } from 'src/environments/environment';
import { BrandListModel } from '../brands/models/brandListModel';

@Injectable({
  providedIn: 'root'
})
export class BrandService {

  apiBaseUrl = environment.baseUrl
  apiBrandUrl = `${this.apiBaseUrl}Brands/`
  constructor(private httpClient: HttpClient) { }

  getAllBrands(page: number, size: number): Observable<ListResponseModel<BrandListModel>> {
    let newwPath = `${this.apiBrandUrl}get-brand-list?Page${page}PageSize=${size}`;
    return this.httpClient.get<ListResponseModel<BrandListModel>>(newwPath);
  }
}
