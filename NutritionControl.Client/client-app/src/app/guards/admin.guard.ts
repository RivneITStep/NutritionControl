import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';
import { AlertifyService } from '../services/layout/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private authService: AuthService,
    private router: Router,
    private alertifyService: AlertifyService) { }
    
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return this.checkRole(state.url);
  }

  checkRole(url: string): boolean {
    if (this.authService.isAdmin()) {
      return true;
    }

    this.authService.redirectUrl = url;
    
    this.router.navigate(['main']);
    this.alertifyService.error("You dont have access")

    return false;
  }
}
