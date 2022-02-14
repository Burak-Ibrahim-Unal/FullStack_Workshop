import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from 'src/app/core/models/listResponseModel';
import { BrandListModel } from '../models/brandListModel';


@Injectable({
  providedIn: 'root'
})
export class BrandService {
  apiUrl = "http://localhost:5001/api/Brands/";

  constructor(private httpClient: HttpClient) { }

  getBrands(page: number, pageSize: number): Observable<ListResponseModel<BrandListModel>> {
    let newPath = this.apiUrl + "getall?page=" + page + "&PageSize=" + pageSize;

    return this.httpClient.get<ListResponseModel<BrandListModel>>(newPath);
  }
}
