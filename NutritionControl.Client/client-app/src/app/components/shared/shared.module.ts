import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../theme/layout/header/header.component';
import { UserNavbarComponent } from '../theme/layout/header/user-navbar/user-navbar.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [
    HeaderComponent,
    UserNavbarComponent
  ],
  imports: [
    NgbModule,
    CommonModule,
    RouterModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    HeaderComponent,
    UserNavbarComponent,
    NgbModule
  ]
})
export class SharedModule { }
