import { Component, OnInit } from '@angular/core';
import { ProductsCrudService } from '../../services/products-crud.service';
import { ApiCollectionResponse, ApiResponse, ApiPaginationResponse } from 'src/app/models/apiResponse';
import { ProductDto } from 'src/app/models/productDto';
import { AlertifyService } from 'src/app/services/layout/alertify.service';

@Component({
  selector: 'app-products-crud',
  templateUrl: './products-crud.component.html',
  styleUrls: ['./products-crud.component.css']
})
export class ProductsCrudComponent implements OnInit {

  page = 1;
  count: number = 0;
  pageSize: number = 10;

  editMode: boolean = false;
  selectedId: number = -1;

  products: Array<ProductDto>;

  constructor(private productsCrudService: ProductsCrudService,
              private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.loadProducts(this.page);
  }


  onEdit(product: ProductDto) {

    if(this.editMode && this.selectedId == product.id) {
      this.productsCrudService.editProduct(product).subscribe((res: ApiResponse) => {
        if(res.isSuccessful){
          this.alertifyService.success(res.message);
          this.selectedId = -1;
          this.loadProducts(this.page);
        }
      })
    }

    if(this.editMode && this.selectedId!= product.id){
      this.selectedId = product.id;
      return;
    }

    this.selectedId = product.id;
    this.editMode = !this.editMode;
  }

  checkEdit(id: number): boolean {
    return (id == this.selectedId && this.editMode);
  }

  onDelete(id: number) {

    if(this.editMode) {
      this.editMode = false;
      this.selectedId = -1;
      return;
    }

    this.alertifyService.confirm("Confirm the deletion","You realy want to delete this item?",()=>{
      this.productsCrudService.deleteProduct(id)
      .subscribe((res: ApiResponse) => {
        if(res.isSuccessful){
          this.alertifyService.success(res.message);
          this.loadProducts(this.page);
        }
      })
    });
  }

  onPageChange(event) {
    this.loadProducts(event);
  }

  onPageSizeChange() {
    this.loadProducts(this.page);
  }

  loadProducts(page: number) {
    this.productsCrudService.getProductsPaginated(page,this.pageSize)
    .subscribe((res: ApiCollectionResponse) => {
      if(res.isSuccessful){
        this.products = res.data;
        this.count = res.count;
      }
    })
  }
}