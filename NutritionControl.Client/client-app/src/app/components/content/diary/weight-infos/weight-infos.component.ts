import { Component, OnInit, OnDestroy, AfterViewInit, NgZone, Input } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";
import { WeightInfoDto } from 'src/app/models/diary/weightInfoDto';
import { ChartsService } from 'src/app/services/layout/charts.service';
import { DiaryService } from 'src/app/services/api/diary.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { ApiCollectionResponse, ApiResponse } from 'src/app/models/apiResponse';
import { AlertifyService } from 'src/app/services/layout/alertify.service';

@Component({
  selector: 'app-weight-infos',
  templateUrl: './weight-infos.component.html',
  styleUrls: ['./weight-infos.component.css']
})
export class WeightInfosComponent implements OnInit, OnDestroy, AfterViewInit {

  private chart: am4charts.XYChart;
  weightInfos: WeightInfoDto[];
  weightInfo: WeightInfoDto = new WeightInfoDto();

  constructor(private zone: NgZone,
    private chartsService: ChartsService,
    private diaryService: DiaryService,
    private authService: AuthService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.getWeightInfos();
  }

  getWeightInfos() {
    const userId = this.authService.getCredentials().userId;
    this.diaryService.getWeightInfos(userId).subscribe((res: ApiCollectionResponse) => {
      if (res.isSuccessful) {
        this.weightInfos = res.data;
        this.chart.data = this.weightInfos.map(x => {
          return {
            date: x.dateOfMeasurement,
            value: x.weightValue
          }
        });
      }
    })
  }

  onWeightAdd() {
    this.weightInfo.dateOfMeasurement = new Date();
    this.diaryService.addWeightInfo(this.weightInfo).subscribe((res: ApiResponse) => {
      if(res.isSuccessful) {
        this.alertifyService.success(res.message);
        this.getWeightInfos();
      }
    })
  }

  ngAfterViewInit(): void {
    this.zone.runOutsideAngular(() => {
      this.chart = am4core.create("weightchart", am4charts.XYChart);
      this.chartsService.initChart(this.chart);
    });
  }

  ngOnDestroy(): void {
    this.zone.runOutsideAngular(() => {
      if (this.chart) {
        this.chart.dispose();
      }
    });
  }
}