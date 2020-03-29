import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../theme/layout/header/header.component';
import { UserNavbarComponent } from '../theme/layout/header/user-navbar/user-navbar.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SideBarComponent } from '../theme/layout/side-bar/side-bar.component';
import { NgCircleProgressModule } from 'ng-circle-progress'


@NgModule({
  declarations: [
    HeaderComponent,
    UserNavbarComponent,
    SideBarComponent
  ],
  imports: [
    NgbModule,
    CommonModule,
    RouterModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    SideBarComponent,
    HeaderComponent,
    UserNavbarComponent,
    NgbModule
  ]
})
export class SharedModule { }
