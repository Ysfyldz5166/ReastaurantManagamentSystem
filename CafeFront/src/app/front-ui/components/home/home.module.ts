import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { RouterModule } from '@angular/router';
import { MenuModule } from '../menu/menu.module';



@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    MenuModule,
    RouterModule.forChild([
      {path: "", component:HomeComponent}
    ])
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
