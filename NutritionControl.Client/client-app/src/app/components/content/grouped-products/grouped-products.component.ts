import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/api/products.service';
import { GroupedProducts } from 'src/app/models/productDto';

@Component({
  selector: 'app-grouped-products',
  templateUrl: './grouped-products.component.html',
  styleUrls: ['./grouped-products.component.css']
})
export class GroupedProductsComponent implements OnInit {

  products: GroupedProducts;

  selectedCategory: string = "";

  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.productsService.getGrouped()
      .subscribe((res: any) => {
        this.products = res.data;
        if (res.count > 0) {
          this.selectedCategory = this.products[0].categoryName;
        }
      });
  }
}