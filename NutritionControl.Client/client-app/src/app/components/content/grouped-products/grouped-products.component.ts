import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/api/products.service';
import { GroupedProducts } from 'src/app/models/productDto';

@Component({
  selector: 'app-grouped-products',
  templateUrl: './grouped-products.component.html',
  styleUrls: ['./grouped-products.component.css']
})
export class GroupedProductsComponent implements OnInit {

  groups: Array<GroupedProducts>;
  categories: Array<string>;

  selectedCategory: string = "";

  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.productsService.getGrouped()
      .subscribe((res: any) => {
        this.groups = res.data;
        this.categories = this.groups.map(x=>x.categoryName);
        if (res.count > 0) {
          this.selectedCategory = this.groups[0].categoryName;
        }
      });
  }
}