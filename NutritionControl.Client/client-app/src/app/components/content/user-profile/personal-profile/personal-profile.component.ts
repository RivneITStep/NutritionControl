import { Component, OnInit, Input } from '@angular/core';
import { ProfileDto } from 'src/app/models/profileDto';

@Component({
  selector: 'app-personal-profile',
  templateUrl: './personal-profile.component.html',
  styleUrls: ['./personal-profile.component.css']
})
export class PersonalProfileComponent implements OnInit {

  @Input() profile: ProfileDto;

  constructor() { }

  ngOnInit() {
  }

}
