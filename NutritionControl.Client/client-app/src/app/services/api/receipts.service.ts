import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_ROUTES } from 'src/app/helpers/consts';
import { Observable } from 'rxjs';
import { ApiResponse, ApiCollectionResponse } from 'src/app/models/apiResponse';

@Injectable({
  providedIn: 'root'
})
export class ReceiptsService {

  constructor(private http: HttpClient) { }

  getReceipts():Observable<ApiResponse> {
    return this.http.get<ApiCollectionResponse>(API_ROUTES.receipts);
  }
}