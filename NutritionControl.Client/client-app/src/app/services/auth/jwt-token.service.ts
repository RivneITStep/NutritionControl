import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ACCESS_TOKEN } from 'src/app/helpers/config';

@Injectable({
  providedIn: 'root'
})
export class JwtTokenService {

  decodedToken: any = null;

  constructor(private jwtHelperService: JwtHelperService) { }

  setToken(token: string): void {
    localStorage.setItem(ACCESS_TOKEN, token);
    this.decodedToken = this.jwtHelperService.decodeToken(localStorage.getItem(ACCESS_TOKEN));
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    return (token != null && !this.jwtHelperService.isTokenExpired(token));
  }

  private getToken(): string {
    return localStorage.getItem(ACCESS_TOKEN);
  }

  private getTokenPayload(): any {
    if (this.decodedToken == null)
      this.decodedToken = this.jwtHelperService.decodeToken(localStorage.getItem(ACCESS_TOKEN));
    return this.decodedToken;
  }
}