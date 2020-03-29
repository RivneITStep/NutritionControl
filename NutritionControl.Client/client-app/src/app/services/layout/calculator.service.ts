import { Injectable } from '@angular/core';
import { number } from '@amcharts/amcharts4/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor() { }

  calculateBMI(weight: number, height: number): number {
    return weight / Math.pow(height / 100, 2);
  }

  calculateDailyCalories(weight: number,
    height: number,
    age: number,
    gender: string,
    activityIndex: number): number {
    let cal = (10 * weight) + (6.25 * height) - (5 * age) + 5;
    if (gender == "Female") {
      cal -= 166;
    }
    return Math.round(cal * activityIndex);
  }
}