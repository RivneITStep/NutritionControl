import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor() { }

  calculateBMI(weight, height): number {
   return weight / Math.pow(height / 100, 2);
  }

}
