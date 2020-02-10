import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { API_ROUTES } from 'src/app/helpers/consts';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }

  getGrouped() {
    return this.http.get(API_ROUTES.products + 'getGrouped');
  }
}