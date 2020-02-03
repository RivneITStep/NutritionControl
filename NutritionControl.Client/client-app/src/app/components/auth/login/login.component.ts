import { Component, OnInit } from '@angular/core';
import { LoginDto } from 'src/app/models/loginDto';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: LoginDto = new LoginDto();

  constructor(private authService: AuthService) { }

  ngOnInit() {
    
  }

  onLogin() {
    this.authService.login(this.model).subscribe(res => {
      console.log(res);
    })
  }

}
