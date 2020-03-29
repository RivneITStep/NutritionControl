import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../services/api/account.service';
import { AuthService } from '../services/auth/auth.service';
import { ApiSingleResponse, ApiResponse } from '../models/apiResponse';
import { AlertifyService } from '../services/layout/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class DiaryGuard implements CanActivate {

  constructor(private accountService: AccountService,
              private authService: AuthService,
              private router: Router,
              private alertifyService: AlertifyService) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const userId = this.authService.getCredentials().userId;

      return this.accountService.getProfile(userId).pipe(map(res=>{
        if(res.message != "User Dont Have Profile") {
          return true;
        }
        else {
          this.alertifyService.warning("You must fill profile first");
          this.router.navigateByUrl('main/profile');
          return false;
        }
      }));
  }
}
