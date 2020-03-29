import { Injectable } from '@angular/core';
import { RegisterDto } from 'src/app/models/auth/registerDto';
import { Observable } from 'rxjs';
import { API_ROUTES } from 'src/app/helpers/consts';
import { HttpClient } from '@angular/common/http';
import { LoginDto } from 'src/app/models/auth/loginDto';
import { TokenService } from './token.service';
import { map } from 'rxjs/operators';
import { ApiResponse, ApiSingleResponse } from 'src/app/models/apiResponse';
import { UserCredentials } from 'src/app/helpers/userCreds';
import { Router } from '@angular/router';
import { PasswordChangeRequest } from 'src/app/models/profileDto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  redirectUrl: string;

  constructor(private http: HttpClient,
    private tokenService: TokenService,
    private router: Router) { }

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

  getCredentials(): UserCredentials {
    let creds = new UserCredentials();
    const token = this.tokenService.getTokenPayload();
    creds.userName = token["sub"];
    creds.userId = token["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
    return creds;
  }

  isAdmin(): boolean {
    const token = this.tokenService.getTokenPayload();
    return token['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']=="admin";
  }

  isLoggedIn(): boolean {
    return this.tokenService.isTokenValid();
  }

  logout(): void {
    this.tokenService.removeToken();
    this.router.navigateByUrl("");
  } 

  changePassword(request: PasswordChangeRequest) : Observable<ApiResponse> {
    return this.http.post<ApiResponse>(API_ROUTES.changePassword, request);
  }
}