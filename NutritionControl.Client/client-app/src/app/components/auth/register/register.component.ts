import { Component, OnInit } from '@angular/core';
import { RegisterDto } from 'src/app/models/registerDto';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
	selector: 'app-register',
	templateUrl: './register.component.html',
	styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

	model: RegisterDto = new RegisterDto();

	constructor(private authService: AuthService) { }

	ngOnInit() { }

	onRegister() {
		this.authService.register(this.model).subscribe(res=>{
			console.log(res);
		})
	}
}