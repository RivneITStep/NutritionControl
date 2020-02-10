import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_ROUTES } from 'src/app/helpers/consts';
import { ApiResponse, ApiSingleResponse } from 'src/app/models/apiResponse';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  getProfile(userId: string): Observable<ApiResponse> {
    return this.http.get<ApiSingleResponse>(API_ROUTES.account + "GetProfile?userId="+userId);
  }
}