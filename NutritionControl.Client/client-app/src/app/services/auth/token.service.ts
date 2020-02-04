import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ACCESS_TOKEN, REFRESH_TOKEN } from 'src/app/helpers/config';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  decodedToken: any = null;

  constructor(private jwtHelperService: JwtHelperService) { }

  setToken(token: string): void {
    localStorage.setItem(ACCESS_TOKEN, token);
    this.decodedToken = this.jwtHelperService.decodeToken(localStorage.getItem(ACCESS_TOKEN));
  }

  setRefreshToken(refreshToken: string): void {
    localStorage.setItem(REFRESH_TOKEN, refreshToken);
  }

  isTokenValid(): boolean {
    const token = this.getToken();
    return (token != null && !this.jwtHelperService.isTokenExpired(token));
  }

  getToken(): string {
    return localStorage.getItem(ACCESS_TOKEN);
  }

  getTokenPayload(): any {
    if (this.decodedToken == null)
      this.decodedToken = this.jwtHelperService.decodeToken(localStorage.getItem(ACCESS_TOKEN));
    return this.decodedToken;
  }

  removeToken(): void {
    localStorage.removeItem(ACCESS_TOKEN);
    localStorage.removeItem(REFRESH_TOKEN);
  }

}