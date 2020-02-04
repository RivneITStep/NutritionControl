import { Component, OnInit } from '@angular/core';
import { RegisterDto } from 'src/app/models/auth/registerDto';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  model: RegisterDto = new RegisterDto();

  constructor(private authService: AuthService,
    private router: Router) { }

  ngOnInit() { }

  onRegister() {
    this.authService.register(this.model).subscribe(res => {
      if (res.isSuccessful) {
        this.router.navigate(["auth/login"]);
      }
      else {
        alert(res.message);
      }
    })
  }
}