import { Injectable } from '@angular/core';
import { RegisterDto } from 'src/app/models/auth/registerDto';
import { Observable } from 'rxjs';
import { API_ROUTES } from 'src/app/helpers/config';
import { HttpClient } from '@angular/common/http';
import { LoginDto } from 'src/app/models/auth/loginDto';
import { TokenService } from './token.service';
import { map } from 'rxjs/operators';
import { ApiResponse, ApiSingleResponse } from 'src/app/models/apiResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  redirectUrl: string;

  constructor(private http: HttpClient,
    private tokenService: TokenService) { }

  register(model: RegisterDto): Observable<ApiResponse> {
    console.log(API_ROUTES.register);
    return this.http.post<ApiResponse>(API_ROUTES.register, model);
  }

  login(model: LoginDto): Observable<ApiResponse> {
    return this.http.post(API_ROUTES.login, model)
      .pipe(
        map((res: ApiSingleResponse) => {
          if (res.isSuccessful) {
            this.tokenService.setToken(res.data.accessToken);
            this.tokenService.setRefreshToken(res.data.refreshToken);
          }
          return res;
        })
      );
  }

  isLoggedIn(): boolean {
    return this.tokenService.isTokenValid();
  }

  logout(): void {
    this.tokenService.removeToken();
  }

}