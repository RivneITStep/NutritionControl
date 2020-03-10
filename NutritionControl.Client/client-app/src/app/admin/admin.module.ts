import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../components/shared/shared.module';
import { ProductsCrudComponent } from './components/products-crud/products-crud.component';

const routes: Routes = [
  {
		path: '',
    component: AdminPanelComponent,
    children: [
      {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full'
      },
      {
        path: 'products',
        component: ProductsCrudComponent
      }
    ]
  }
]

@NgModule({
  declarations: [AdminPanelComponent, ProductsCrudComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class AdminModule { }
