import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResponse, ApiCollectionResponse } from 'src/app/models/apiResponse';
import { Observable } from 'rxjs';
import { API_ROUTES } from 'src/app/helpers/consts';
import { ProductDto } from 'src/app/models/productDto';

@Injectable({
  providedIn: 'root'
})
export class ProductsCrudService {

  constructor(private http: HttpClient) { }

  getProducts():Observable<ApiCollectionResponse> {
    return this.http.get<ApiCollectionResponse>(API_ROUTES.products);
  }

  deleteProduct(id):Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(API_ROUTES.products + "?id=" + id);
  }

  editProduct(product: ProductDto): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(API_ROUTES.products,product);
  }

  getProductsPaginated(page: number,pageSize: number): Observable<ApiResponse> {
    return this.http.get<ApiCollectionResponse>(API_ROUTES.products + "paged/" + page + "/" + pageSize);
  }
}