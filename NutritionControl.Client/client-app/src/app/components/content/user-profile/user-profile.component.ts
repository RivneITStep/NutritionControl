import { Component, OnInit } from '@angular/core';
import { NgbTabsetConfig } from '@ng-bootstrap/ng-bootstrap';
import { ProfileDto } from 'src/app/models/profileDto';
import { AuthService } from 'src/app/services/auth/auth.service';
import { AccountService } from 'src/app/services/api/account.service';
import { ApiSingleResponse } from 'src/app/models/apiResponse';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
  providers: [NgbTabsetConfig]
})
export class UserProfileComponent implements OnInit {

  profile: ProfileDto = new ProfileDto();
  public cancelCallback: Function;

  constructor(config: NgbTabsetConfig,
    private authService: AuthService,
    private accountService: AccountService) {
    config.justify = 'fill';
  }

  ngOnInit() {    
    this.getInfo();
    this.cancelCallback = this.getInfo.bind(this);
  }

  getInfo() {
    const userId = this.authService.getCredentials().userId;
    this.accountService.getProfile(userId).subscribe((res: ApiSingleResponse) => {
      if(res.message!="User Dont Have Profile"){
        this.profile = res.data;
      }
      else {
        this.profile = new ProfileDto();
      }
    });
  }
}