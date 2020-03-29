import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/api/products.service';
import { ProductDto } from 'src/app/models/productDto';
import { Observable } from 'rxjs';
import { ApiCollectionResponse, ApiResponse, ApiSingleResponse } from 'src/app/models/apiResponse';
import { map, debounceTime } from 'rxjs/operators';
import { NgbDateStruct, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';
import { DiaryService } from 'src/app/services/api/diary.service';
import { FoodIntakeDto } from 'src/app/models/diary/foodIntake';
import { ProfileDto } from 'src/app/models/profileDto';
import { AccountService } from 'src/app/services/api/account.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CalculatorService } from 'src/app/services/layout/calculator.service';

@Component({
  selector: 'app-food-intakes',
  templateUrl: './food-intakes.component.html',
  styleUrls: ['./food-intakes.component.css']
})
export class FoodIntakesComponent implements OnInit {

  /* FoodIntakes */

  foodIntakes: Array<FoodIntakeDto>;
  shownfoodIntakes: Array<FoodIntakeDto>;
  currentType = "Breakfast"

  /* Add Food Intake */

  products: Array<ProductDto>;
  selectedProduct: ProductDto;
  foodWeight: number;

  intakeType: string = "Breakfast";

  time: any = {
    hour: new Date().getHours(),
    minute: new Date().getMinutes()
  };

  /* Current Date */

  selectedDate: NgbDateStruct;
  date: { year: number, month: number };

  /* Profile */

  profile: ProfileDto;
  dailyCalories: number;
  dailyFats: number;
  dailyCarbohydrates: number;
  dailyProteins: number;

  calories: number = 1;
  fats: number = 1;
  carbohydrates: number = 1;
  proteins: number = 1;

  constructor(private productService: ProductsService,
    private calendar: NgbCalendar,
    private diaryService: DiaryService,
    private accountService: AccountService,
    private authService: AuthService,
    private calcService: CalculatorService ) { }

  ngOnInit() {
    this.selectedDate = this.calendar.getToday();

    this.productService.getAll().subscribe((res: ApiCollectionResponse) => {
      if (res.isSuccessful) {
        this.products = res.data;
      }
    });

    const userId = this.authService.getCredentials().userId;
    this.accountService.getProfile(userId).subscribe((res:ApiSingleResponse) => {
      if(res.isSuccessful) {
        this.profile = res.data;
        this.dailyCalories = this.calcService.calculateDailyCalories(this.profile.weight,
          this.profile.height,
          this.profile.age,
          this.profile.gender,
          1.375);
        this.dailyFats = Math.round(this.dailyCalories * 0.3 / 9);
        this.dailyProteins = Math.round(this.dailyCalories * 0.3 / 4);
        this.dailyCarbohydrates =Math.round (this.dailyCalories * 0.4 /4);

        this.getIntakes(this.parseDate(this.selectedDate))
      }
    });
  }

  calculateValues() {
    this.calories = 0;
    this.fats = 0;
    this.carbohydrates = 0;
    this.proteins = 0;
    this.foodIntakes.forEach((element:FoodIntakeDto) => {
      this.calories += Math.round(element.foodWeight / 100 * element.product.caloriesValue)
      this.fats += Math.round(element.foodWeight / 100 * element.product.fats)
      this.proteins += Math.round(element.foodWeight / 100 * element.product.protein)
      this.carbohydrates += Math.round(element.foodWeight / 100 * element.product.carbohydrates)
    });
  }

  getIntakes(date: Date) {
    this.diaryService.getFoodIntakes(date).subscribe((res: ApiCollectionResponse) => {
      if (res.isSuccessful) {
        this.foodIntakes = res.data;
        this.changeType(this.currentType);
        this.calculateValues();
      }
    })
  }

  changeType(event: string) {
    this.shownfoodIntakes = this.foodIntakes.filter(x=>x.type == event);
  }
  
  parseDate(date: NgbDateStruct): Date {
    let d = new Date();
    d.setFullYear(date.year);
    d.setMonth(date.month-1);
    d.setDate(date.day);
    return d;
  }

  onAdd() {
    let date = this.parseDate(this.selectedDate);
    date.setHours(this.time.hour);
    date.setMinutes(this.time.minute);
    date.setSeconds(0);
    let intake = new FoodIntakeDto();
    intake.dateOfIntake = date;
    intake.foodWeight = this.foodWeight;
    intake.productId = this.selectedProduct.id;
    intake.type = this.intakeType;
    this.diaryService.addFoodIntake(intake).subscribe((res: ApiResponse) => {
      if (res.isSuccessful) {
        this.getIntakes(this.parseDate(this.selectedDate))
      }
    })
  }

  onDateSelect() {
    this.getIntakes(this.parseDate(this.selectedDate));
  }

  searchProduct = (text$: Observable<string>) =>
    text$.pipe(
      map(term => term === '' ? [] :
        this.products.filter(p => p.name.toLowerCase().indexOf(term.toLowerCase()) > -1).slice(0, 10)));

  formatter = (p: { name: string }) => p.name;

}