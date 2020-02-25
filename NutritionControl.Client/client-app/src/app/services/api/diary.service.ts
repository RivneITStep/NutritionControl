import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse, ApiCollectionResponse } from 'src/app/models/apiResponse';
import { API_ROUTES } from 'src/app/helpers/consts';
import { WeightInfoDto } from 'src/app/models/diary/weightInfoDto';
import { WaterValueDto } from 'src/app/models/diary/waterValueDto';

@Injectable({
  providedIn: 'root'
})
export class DiaryService {

  constructor(private http: HttpClient) { }

  getWeightInfos(userId: string): Observable<ApiResponse> {
    return this.http.get<ApiCollectionResponse>(API_ROUTES.diary + "GetWeightInfos?userId=" + userId);
  }

  getWaterValues(userId: string): Observable<ApiResponse> {
    return this.http.get<ApiCollectionResponse>(API_ROUTES.diary + "GetWaterValues?userId=" + userId);
  }

  addWeightInfo(model: WeightInfoDto): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(API_ROUTES.diary + "AddWeightInfo",model);
  }

  addWaterValue(model: WaterValueDto): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(API_ROUTES.diary + "AddWaterValue",model);
  }
}