import { Injectable } from '@angular/core';
import { RegisterDto } from 'src/app/models/registerDto';
import { Observable } from 'rxjs';
import { API_ROUTES } from 'src/app/helpers/config';
import { HttpClient } from '@angular/common/http';
import { LoginDto } from 'src/app/models/loginDto';
import { JwtTokenService } from './jwt-token.service';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,
    private jwtTokenService: JwtTokenService) { }

  register(model: RegisterDto): Observable<any> {
    console.log(API_ROUTES.register);
    return this.http.post(API_ROUTES.register, model);
  }

  login(model: LoginDto): Observable<any> {
    return this.http.post(API_ROUTES.login, model)
      .pipe(
        map((res: any) => {

          this.jwtTokenService.setToken(res.data);
          
          console.log(this.jwtTokenService.decodedToken);
        })
      );
  }
}