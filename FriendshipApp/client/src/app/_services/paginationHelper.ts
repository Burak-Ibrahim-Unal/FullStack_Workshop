import { map } from 'rxjs/operators';
import { HttpClient, HttpParams } from '@angular/common/http';
import { PaginatedResult } from "../_models/pagination";

export function getPaginatedResults<T>(url, params, httpClient:HttpClient) {
  const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();
  return httpClient.get<T>(url, { observe: "response", params }).pipe(
    map(response => {
      paginatedResult.result = response.body;
      if (response.headers.get("Pagination") !== null) {
        paginatedResult.pagination = JSON.parse(response.headers.get("Pagination"));
      }
      return paginatedResult;
    })
  );
}

export function getPaginationHeaders(pageNumber: number, pageSize: number) {
  let params = new HttpParams();
  params = params.append("pageNumber", pageNumber.toString());
  params = params.append("pageSize", pageSize.toString());

  return params;

}
