import { Component, OnInit } from '@angular/core';
import { ApiCollectionResponse, ApiResponse } from 'src/app/models/apiResponse';
import { CategoryDto } from 'src/app/models/categoryDto';
import { AlertifyService } from 'src/app/services/layout/alertify.service';
import { CategoriesCrudService } from '../../services/categories-crud.service';

@Component({
  selector: 'app-categories-crud',
  templateUrl: './categories-crud.component.html',
  styleUrls: ['./categories-crud.component.css']
})
export class CategoriesCrudComponent implements OnInit {

  page = 1;
  count: number = 0;
  pageSize: number = 10;

  editMode: boolean = false;
  selectedId: number = -1;

  categories: Array<CategoryDto>;
  newCategory: CategoryDto = {
    name: "",
    id: 0,
    productsCount: 0
  };

  constructor(private categoriesCrudService: CategoriesCrudService,
              private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.loadProducts(this.page);
  }


  onEdit(category: CategoryDto) {

    if(this.editMode && this.selectedId == category.id) {
      this.categoriesCrudService.editCategory(category).subscribe((res: ApiResponse) => {
        if(res.isSuccessful){
          this.alertifyService.success(res.message);
          this.selectedId = -1;
          this.loadProducts(this.page);
        }
      })
    }

    if(this.editMode && this.selectedId!= category.id){
      this.selectedId = category.id;
      return;
    }

    this.selectedId = category.id;
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

    this.alertifyService.confirm("Confirm the deletion","You realy want to delete this category? ALL products will be deleted",()=>{
      this.categoriesCrudService.deleteCategory(id)
      .subscribe((res: ApiResponse) => {
        if(res.isSuccessful){
          this.alertifyService.success(res.message);
          this.loadProducts(this.page);
        }
      })
    });
  }

  onAdd() {
    this.categoriesCrudService.addCategory(this.newCategory).subscribe((res: ApiResponse) => {
      if(res.isSuccessful){
        this.alertifyService.success("Product was added");
        this.loadProducts(this.page);
      }
    })
  }

  onPageChange(event) {
    this.loadProducts(event);
  }

  onPageSizeChange() {
    this.loadProducts(this.page);
  }

  loadProducts(page: number) {
    this.categoriesCrudService.getCategoriesPaginated(page,this.pageSize)
    .subscribe((res: ApiCollectionResponse) => {
      if(res.isSuccessful){
        this.categories = res.data;
        this.count = res.count;
      }
    })
  }
}