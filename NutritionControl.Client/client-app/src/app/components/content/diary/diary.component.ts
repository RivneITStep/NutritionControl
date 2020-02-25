import { Component, OnInit, AfterViewInit, NgZone } from '@angular/core';
import { DiaryService } from 'src/app/services/api/diary.service';
import { WeightInfoDto } from 'src/app/models/diary/weightInfoDto';
import { ApiCollectionResponse } from 'src/app/models/apiResponse';
import { AuthService } from 'src/app/services/auth/auth.service';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";

am4core.useTheme(am4themes_animated);

@Component({
  selector: 'app-diary',
  templateUrl: './diary.component.html',
  styleUrls: ['./diary.component.css']
})
export class DiaryComponent implements OnInit {

  constructor(private diaryService: DiaryService,
    private authService: AuthService) { }

  ngOnInit() {

  }
}