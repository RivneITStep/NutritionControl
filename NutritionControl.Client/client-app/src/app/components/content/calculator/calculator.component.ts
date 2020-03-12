import { Component, OnInit } from '@angular/core';
import { CalculatorService } from 'src/app/services/layout/calculator.service';
import { BMIData } from 'src/app/models/bmiData';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  gender: string = "male";

  _height: number = 170;
  set height(v: number) {
    this._height = v;
    this.calculate();
  }
  get height() {
    return this._height;
  }
    
  _weight: number = 70;
  set weight(v: number) {
    this._weight = v;
    this.calculate();
  }
  get weight() {
    return this._weight;
  }

  index: number;
  indexratio: string = '-2%';

  constructor(private calculatorService: CalculatorService) { }

  ngOnInit() {
    this.calculate();
  }

  calculate() {
    this.index = this.calculatorService.calculateBMI(this.weight,this.height);

    let ratio = ((this.index-15) * 100)/(40-15);
    console.log(ratio);
    if(ratio>97){
      ratio = 97
    }
    if(ratio<-2){
      ratio = -2
    }
    
    this.indexratio = ratio + '%';
  }
}