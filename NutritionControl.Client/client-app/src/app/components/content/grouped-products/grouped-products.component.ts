import { Component, OnInit } from '@angular/core';
import { ProductsService } from 'src/app/services/api/products.service';
import { GroupedProducts, ProductDto } from 'src/app/models/productDto';
import { ApiResponse } from 'src/app/models/apiResponse';
import { AlertifyService } from 'src/app/services/layout/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';

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
    private alertifyService: AlertifyService,
    private router: Router) { }

  ngOnInit() {
    this.getProducts();
  }

  getProducts() {
    this.productsService.getGrouped()
    .subscribe((res: any) => {
      this.groups = res.data;
      if (this.router.url == "/main/products/favourite") {
        this.groups = this.groups.filter(x => x.products.some(x => x.isLiked) == true);
      }
      this.categories = this.groups.map(x => x.categoryName);
      if (res.count > 0) {
        this.selectedCategory = this.groups[0].categoryName;
      }

      if (this.router.url == "/main/products/favourite") {
        this.groups.forEach(group => {
          group.products = group.products.filter(x => x.isLiked)
        });
      }

    });
  }

  onLikeClick(product: ProductDto) {
    this.productsService.likeProduct(product.id).subscribe((res: ApiResponse) => {
      if (res.isSuccessful) {
        this.alertifyService.success(res.message);
        if (this.router.url == "/main/products/favourite") {
          this.getProducts();
        }
        product.isLiked = !product.isLiked;
      }
    })
  }

  changeCategoriesVisibility() {
    this.isCategoriesVisible = !this.isCategoriesVisible;
  }
}