import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/api/products.service';
import { ProductDto } from 'src/app/models/productDto';
import { Observable } from 'rxjs';
import { ApiCollectionResponse } from 'src/app/models/apiResponse';
import { map, debounceTime } from 'rxjs/operators';
import { NgbDateStruct, NgbCalendar } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-food-intakes',
  templateUrl: './food-intakes.component.html',
  styleUrls: ['./food-intakes.component.css']
})
export class FoodIntakesComponent implements OnInit {

  /* Add Food Intake */

  products: Array<ProductDto>;
  selectedProduct: ProductDto;

  intakeType: string = "Breakfast";

  time: any = {
    hour: new Date().getHours(),
    minute: new Date().getMinutes()
  };

  /* Current Date */

  selectedDate: NgbDateStruct;
  date: {year: number, month: number};

  constructor(private productService: ProductsService,
              private calendar: NgbCalendar) { }

  ngOnInit() {

    this.selectedDate = this.calendar.getToday();

    this.productService.getAll().subscribe((res: ApiCollectionResponse) => {
      if (res.isSuccessful) {
        this.products = res.data;
      }
    });
  }

  onAdd() {
    let date = new Date();
    date.setHours(this.time.hour);
    date.setMinutes(this.time.minute);
    date.setSeconds(0);
    console.log(date);
  }

  searchProduct = (text$: Observable<string>) =>
    text$.pipe(
      map(term => term === '' ? [] :
        this.products.filter(p => p.name.toLowerCase().indexOf(term.toLowerCase()) > -1).slice(0, 10)));

  formatter = (p: { name: string }) => p.name;

}