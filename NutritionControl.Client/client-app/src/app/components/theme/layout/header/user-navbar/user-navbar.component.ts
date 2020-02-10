import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-navbar',
  templateUrl: './user-navbar.component.html',
  styleUrls: ['./user-navbar.component.css']
})
export class UserNavbarComponent implements OnInit {

  userName: string;

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit() {
    if(this.authService.getCredentials()==null) {
      this.userName = "Username";
    }
    else {
      this.userName = this.authService.getCredentials().userName;
    }
  }

  onLogout(): void {
    this.authService.logout();
    this.router.navigateByUrl("");
  }
}