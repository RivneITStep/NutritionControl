import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { ACCESS_TOKEN, APP_ROUTES } from './helpers/consts';
import { AuthGuard } from './guards/auth.guard';
import { WelcomeComponent } from './components/theme/layout/welcome/welcome.component';
import { SharedModule } from './components/shared/shared.module';
import { ErrorHandlingInterceptor } from './helpers/interceptors/errorHandling.interceptor';
import { CalculatorComponent } from './components/content/calculator/calculator.component';
import { FoodIntakesComponent } from './components/content/diary/food-intakes/food-intakes.component';
import { ReceiptsComponent } from './components/content/receipts/receipts.component';
import { AdminGuard } from './guards/admin.guard';

const routes: Routes = [
  {
    path: '',
    component: WelcomeComponent,
  },
  {
    path: APP_ROUTES.main,
    loadChildren: () => import('./components/theme/main/main.module').then(m=>m.MainModule),
    canActivate: [AuthGuard]
  },
  {
    path: APP_ROUTES.auth,
    loadChildren: () => import('./components/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: APP_ROUTES.admin,
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canActivate: [AdminGuard]
  },
  {
    path: '**',
    redirectTo: ''
  }
]

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    SharedModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => { return localStorage.getItem(ACCESS_TOKEN) },
        whitelistedDomains: ['localhost:44322'],
        blacklistedRoutes: ['localhost:44322/api/auth']
      }
    }),
    RouterModule.forRoot(routes)
  ],
  providers: [
    JwtHelperService,
    {
      provide: HTTP_INTERCEPTORS, 
      useClass: ErrorHandlingInterceptor, 
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }