import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/models/auth/loginDto';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: LoginDto = new LoginDto();

  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit() { }

  onLogin() {
    if(this.model.email==null || this.model.password==null)
       return;

    this.authService.login(this.model).subscribe(res => {
      if (res.isSuccessful && this.authService.isLoggedIn()) {
        let redirectUrl = this.authService.redirectUrl ? this.router.parseUrl(this.authService.redirectUrl) : '';
        this.router.navigateByUrl(redirectUrl);
      }
      else {
        alert(res.message);
      }
    })
  }
}