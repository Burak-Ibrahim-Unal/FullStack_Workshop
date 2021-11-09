import { ResponseModel } from './../Models/responseModel';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListResponseModel } from '../Models/listResponseModel';
import { Product } from '../Models/product';

@Injectable({
    providedIn: 'root',
})
export class ProductService {
    apiURL = 'https://localhost:44324/api/';

    constructor(private httpClient: HttpClient) { }

    getProducts(): Observable<ListResponseModel<Product>> {
        let newPath = this.apiURL + 'products/getall';
        return this.httpClient.get<ListResponseModel<Product>>(newPath);
    }

    getProductsByCategoryId(
        categoryId: number
    ): Observable<ListResponseModel<Product>> {
        let newPath =
            this.apiURL + 'products/getallbycategoryid?categoryId=' + categoryId;
        return this.httpClient.get<ListResponseModel<Product>>(newPath);
    }

    addProduct(product: Product): Observable<ResponseModel> {
        return this.httpClient.post<ResponseModel>(this.apiURL + "products/add", product);
    }
}
