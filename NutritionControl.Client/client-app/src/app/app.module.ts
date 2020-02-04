import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { MainComponent } from './components/theme/main/main.component';
import { RouterModule, Routes } from '@angular/router'
import { HttpClientModule } from '@angular/common/http';
import { AuthModule } from './components/auth/auth.module';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { ACCESS_TOKEN } from './helpers/config';
import { AuthGuard } from './guards/auth.guard';
import { HeaderComponent } from './components/theme/layout/header/header.component';

const routes: Routes = [
  {
    path: '',
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
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AuthModule,
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
