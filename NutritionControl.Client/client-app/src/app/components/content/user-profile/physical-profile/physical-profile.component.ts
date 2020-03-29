import { Component, OnInit, Input } from '@angular/core';
import { ProfileDto } from 'src/app/models/profileDto';
import { AlertifyService } from 'src/app/services/layout/alertify.service';
import { AccountService } from 'src/app/services/api/account.service';
import { ApiResponse } from 'src/app/models/apiResponse';

@Component({
  selector: 'app-physical-profile',
  templateUrl: './physical-profile.component.html',
  styleUrls: ['./physical-profile.component.css']
})
export class PhysicalProfileComponent implements OnInit {

  @Input() profile: ProfileDto;
  @Input() cancelCallback: Function;
  isChanged: boolean = false;

  constructor(private accountService: AccountService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {

  }

  onSave(): void {
    this.accountService.saveProfile(this.profile).subscribe((res: ApiResponse) => {
      if (res.isSuccessful) {
        this.alertifyService.success(res.message);
      }
    });
  }
  onCancel() {
    this.cancelCallback();
    this.isChanged = false;
  }
}