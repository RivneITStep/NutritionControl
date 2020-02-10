import { Component, OnInit, Input } from '@angular/core';
import { ProfileDto } from 'src/app/models/profileDto';

@Component({
  selector: 'app-physical-profile',
  templateUrl: './physical-profile.component.html',
  styleUrls: ['./physical-profile.component.css']
})
export class PhysicalProfileComponent implements OnInit {

  @Input() profile: ProfileDto;

  constructor() { 
  }

  ngOnInit() {
  }

}
