import { Injectable } from '@angular/core';
import { ApiCollectionResponse, ApiResponse } from 'src/app/models/apiResponse';
import { Observable } from 'rxjs';
import { CategoryDto } from 'src/app/models/categoryDto';
import { API_ROUTES } from 'src/app/helpers/consts';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoriesCrudService {

  constructor(private http: HttpClient) { }

  getCategories():Observable<ApiCollectionResponse> {
    return this.http.get<ApiCollectionResponse>(API_ROUTES.categories);
  }

  deleteCategory(id):Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(API_ROUTES.categories + "?id=" + id);
  }

  editCategory(category: CategoryDto): Observable<ApiResponse> {
    return this.http.put<ApiResponse>(API_ROUTES.categories,category);
  }

  getCategoriesPaginated(page: number,pageSize: number): Observable<ApiResponse> {
    return this.http.get<ApiCollectionResponse>(API_ROUTES.categories + "paged/" + page + "/" + pageSize);
  }

  addCategory(category: CategoryDto): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(API_ROUTES.categories, category);
  }
}