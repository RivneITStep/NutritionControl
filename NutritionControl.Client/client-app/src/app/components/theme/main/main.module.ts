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
import { FoodIntakesComponent } from '../../content/diary/food-intakes/food-intakes.component';
import { ReceiptsComponent } from '../../content/receipts/receipts.component';
import { NgCircleProgressModule } from 'ng-circle-progress';
import { ProfileGalleryComponent } from '../../content/user-profile/profile-gallery/profile-gallery.component';
import { DiaryGuard } from 'src/app/guards/diary.guard';

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
        component: DiaryComponent,
        canActivate: [DiaryGuard]
      },
      {
        path: 'calculator',
        component: CalculatorComponent
      },
      {
        path: 'receipts',
        component: ReceiptsComponent
      },
      {
        path: 'products/favourite',
        component: GroupedProductsComponent,
      },
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
    FoodIntakesComponent,
    CalculatorComponent,
    ReceiptsComponent,
    ProfileGalleryComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    NgCircleProgressModule.forRoot({
      // set defaults here
      outerStrokeWidth: 6,
      innerStrokeWidth: 6,
      outerStrokeColor: "#78C000",
      innerStrokeColor: "#C7E596",
      animationDuration: 500,
      showTitle: true,
      showSubtitle: true,
      showInnerStroke: false,
      showUnits: false,
      titleFontSize: "12",
      responsive: true,
      space:0,
      animateTitle: true
    })
  ],
  bootstrap: [MainComponent]
})
export class MainModule { }
