import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/api/products.service';
import { GroupedProducts, ProductDto } from 'src/app/models/productDto';
import { ApiResponse } from 'src/app/models/apiResponse';
import { AlertifyService } from 'src/app/services/layout/alertify.service';

@Component({
  selector: 'app-grouped-products',
  templateUrl: './grouped-products.component.html',
  styleUrls: ['./grouped-products.component.css']
})
export class GroupedProductsComponent implements OnInit {

  groups: Array<GroupedProducts>;
  categories: Array<string>;

  selectedCategory: string = "";
  isCategoriesVisible: boolean = true;

  constructor(private productsService: ProductsService,
              private alertifyService: AlertifyService) { }

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

  onLikeClick(product: ProductDto) {
    this.productsService.likeProduct(product.id).subscribe((res: ApiResponse) => {
      if(res.isSuccessful) {
        this.alertifyService.success(res.message);
        product.isLiked = !product.isLiked;
      }
    })
  }

  changeCategoriesVisibility() {
    this.isCategoriesVisible = !this.isCategoriesVisible;
  }
}