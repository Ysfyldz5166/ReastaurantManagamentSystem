import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserModule } from './user/user.module';
import { CategoryModule } from './category/category.module';
import { UserComponent } from './user/user.component';
import { DashboardModule } from './dashboard/dashboard.module';
import { DashboardComponent } from './dashboard/dashboard.component';



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    UserModule,
    CategoryModule,
    DashboardModule
  ],
  exports: [
    UserComponent,
    DashboardComponent
  ]

})
export class ComponentsModule { }
