import { Component, OnInit, Input } from '@angular/core';
import { ProfileDto, PasswordChangeRequest } from 'src/app/models/profileDto';
import { AccountService } from 'src/app/services/api/account.service';
import { ApiResponse } from 'src/app/models/apiResponse';
import { AlertifyService } from 'src/app/services/layout/alertify.service';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-personal-profile',
  templateUrl: './personal-profile.component.html',
  styleUrls: ['./personal-profile.component.css']
})
export class PersonalProfileComponent implements OnInit {

  @Input() profile: ProfileDto;
  @Input() cancelCallback: Function;
  isPasswordChanged: boolean = false;
  passwordChangeReq: PasswordChangeRequest = new PasswordChangeRequest();
  isChanged: boolean = false;

  constructor(private accountService: AccountService, 
              private alertifyService: AlertifyService,
              private authService: AuthService) {  }

  ngOnInit() {
  }

  onSave(): void {

    if(this.profile.name == null || this.profile.name == '' ||
    this.profile.surname == null || this.profile.surname == '' ||
    this.profile.weight == null || this.profile.weight <= 0 ||
    this.profile.height == null || this.profile.height <= 0||
    this.profile.gender == null || this.profile.gender == '' ||
    this.profile.age == null || this.profile.age <=0 )
    {
      this.alertifyService.error("You must fill all fields");
      return;
    }

    return;

    this.accountService.saveProfile(this.profile).subscribe((res: ApiResponse) => {
      if(res.isSuccessful) {
        this.alertifyService.success(res.message);
      }
    });
    if(this.isPasswordChanged){
      this.authService.changePassword(this.passwordChangeReq).subscribe((res: ApiResponse) => {
        if(res.isSuccessful) {
          this.alertifyService.success(res.message);
        }
      });
    }
  }

  onCancel() {
    this.cancelCallback();
    this.passwordChangeReq.confirmPassword = '';
    this.passwordChangeReq.newPassword = '';
    this.passwordChangeReq.oldPassword = '';
    this.isChanged = false;
  }
}
