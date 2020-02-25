import { Component, OnInit, OnDestroy, AfterViewInit, NgZone } from '@angular/core';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";
import am4themes_animated from "@amcharts/amcharts4/themes/animated";
import { WaterValueDto } from 'src/app/models/diary/waterValueDto';
import { ApiCollectionResponse, ApiResponse } from 'src/app/models/apiResponse';
import { AuthService } from 'src/app/services/auth/auth.service';
import { DiaryService } from 'src/app/services/api/diary.service';
import { ChartsService } from 'src/app/services/layout/charts.service';

@Component({
  selector: 'app-water-values',
  templateUrl: './water-values.component.html',
  styleUrls: ['./water-values.component.css']
})
export class WaterValuesComponent implements OnInit, OnDestroy, AfterViewInit {

  private chart: am4charts.XYChart;
  waterValues: WaterValueDto[];
  waterValue: WaterValueDto = new WaterValueDto();

  constructor(private zone: NgZone,
    private chartsService: ChartsService,
    private diaryService: DiaryService,
    private authService: AuthService) { }

  ngOnInit() {
   this.getWaterValues();
  }

  getWaterValues() {
    const userId = this.authService.getCredentials().userId;
    this.diaryService.getWaterValues(userId).subscribe((res: ApiCollectionResponse) => {
      if (res.isSuccessful) {
        this.waterValues = res.data;
        this.chart.data = this.waterValues.map(x => {
          return {
            date: x.dateOfMeasurement,
            value: x.value
          }
        });
      }
    })
  }

  onWaterAdd() {
    this.waterValue.dateOfMeasurement = new Date();
    this.diaryService.addWaterValue(this.waterValue).subscribe((res: ApiResponse) => {
      if(res.isSuccessful) {
        this.getWaterValues();
      }
    })
  }

  ngAfterViewInit(): void {
    this.zone.runOutsideAngular(() => {
      this.chart = am4core.create("waterchart", am4charts.XYChart);
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