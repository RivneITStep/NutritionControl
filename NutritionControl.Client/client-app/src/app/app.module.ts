import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MainComponent } from './components/theme/main/main.component';
import { RouterModule, Routes } from '@angular/router'
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from './components/auth/auth.module';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { ACCESS_TOKEN } from './helpers/consts';
import { AuthGuard } from './guards/auth.guard';
import { HeaderComponent } from './components/theme/layout/header/header.component';
import { SideBarComponent } from './components/theme/layout/side-bar/side-bar.component';
import { WelcomeComponent } from './components/theme/layout/welcome/welcome.component';
import { GroupedProductsComponent } from './components/content/grouped-products/grouped-products.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserNavbarComponent } from './components/theme/layout/header/user-navbar/user-navbar.component';
import { UserProfileComponent } from './components/content/user-profile/user-profile.component';
import { PersonalProfileComponent } from './components/content/user-profile/personal-profile/personal-profile.component';
import { PhysicalProfileComponent } from './components/content/user-profile/physical-profile/physical-profile.component';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    component: WelcomeComponent,
  },
  {
    path: 'main',
    component: MainComponent,
    //canActivate: [AuthGuard]
  },
  {
    path: 'auth',
    loadChildren: () => import('./components/auth/auth.module').then(m => m.AuthModule)
  }
]

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    HeaderComponent,
    SideBarComponent,
    WelcomeComponent,
    GroupedProductsComponent,
    UserNavbarComponent,
    UserProfileComponent,
    PersonalProfileComponent,
    PhysicalProfileComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AuthModule,
    FormsModule,
    NgbModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => { return localStorage.getItem(ACCESS_TOKEN) },
        whitelistedDomains: ['localhost:44322'],
        blacklistedRoutes: ['localhost:44322/api/auth']
      }
    }),
    RouterModule.forRoot(routes)
  ],
  providers: [JwtHelperService],
  bootstrap: [AppComponent]
})
export class AppModule { }