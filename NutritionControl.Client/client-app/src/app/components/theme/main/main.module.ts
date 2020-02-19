import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupedProductsComponent } from '../../content/grouped-products/grouped-products.component';
import { Routes, RouterModule } from '@angular/router';
import { UserProfileComponent } from '../../content/user-profile/user-profile.component';
import { SideBarComponent } from '../layout/side-bar/side-bar.component';
import { PersonalProfileComponent } from '../../content/user-profile/personal-profile/personal-profile.component';
import { PhysicalProfileComponent } from '../../content/user-profile/physical-profile/physical-profile.component';
import { MainComponent } from './main.component';
import { SharedModule } from '../../shared/shared.module';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        redirectTo: 'products',
        pathMatch: 'full'
      },
      {
        path: 'products',
        component: GroupedProductsComponent,
      },
      {
        path: 'profile',
        component: UserProfileComponent
      }
    ]
  }
]

@NgModule({
  declarations: [
    MainComponent,
    GroupedProductsComponent,
    UserProfileComponent,
    SideBarComponent,
    PersonalProfileComponent,
    PhysicalProfileComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  bootstrap: [MainComponent]
})
export class MainModule { }
