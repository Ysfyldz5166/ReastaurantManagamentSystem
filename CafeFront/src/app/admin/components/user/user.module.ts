import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserManageComponent } from './user-manage/user-manage.component';



@NgModule({
  declarations: [
    UserComponent,
    UserListComponent,
    UserManageComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      {path: '', component: UserComponent},
      {path:'list', component:UserListComponent},
      {path:'manage-user/:id', component:UserManageComponent}

    ])
  ],
  exports: [
    UserComponent
  ] 
})
export class UserModule { 
}
