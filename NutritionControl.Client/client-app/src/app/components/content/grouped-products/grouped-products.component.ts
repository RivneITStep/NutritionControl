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

  scrollToCategory(categoryName: string) {
    //mda
    let el = document.getElementById(categoryName);
    var rect = el.getBoundingClientRect();
    window.scrollTo({top: rect.top + document.documentElement.scrollTop - 90,behavior:"smooth"})

    this.selectedCategory = categoryName;
  }
}