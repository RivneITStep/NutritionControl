import { NgModule } from '@angular/core';
import { GroupedProductsComponent } from '../../content/grouped-products/grouped-products.component';
import { Routes, RouterModule } from '@angular/router';
import { UserProfileComponent } from '../../content/user-profile/user-profile.component';
import { SideBarComponent } from '../layout/side-bar/side-bar.component';
import { PersonalProfileComponent } from '../../content/user-profile/personal-profile/personal-profile.component';
import { PhysicalProfileComponent } from '../../content/user-profile/physical-profile/physical-profile.component';
import { MainComponent } from './main.component';
import { SharedModule } from '../../shared/shared.module';
import { SidebarNavComponent } from '../../content/sidebar-nav/sidebar-nav.component';
import { DiaryComponent } from '../../content/diary/diary.component';
import { WeightInfosComponent } from '../../content/diary/weight-infos/weight-infos.component';
import { WaterValuesComponent } from '../../content/diary/water-values/water-values.component';
import { CalculatorComponent } from '../../content/calculator/calculator.component';

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
      },
      {
        path: 'diary',
        component: DiaryComponent
      },
      {
        path: 'calculator',
        component: CalculatorComponent
      }
    ]
  }
]

@NgModule({
  declarations: [
    MainComponent,
    GroupedProductsComponent,
    UserProfileComponent,
    PersonalProfileComponent,
    PhysicalProfileComponent,
    SidebarNavComponent,
    DiaryComponent,
    WeightInfosComponent,
    WaterValuesComponent,
    CalculatorComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ],
  bootstrap: [MainComponent]
})
export class MainModule { }
