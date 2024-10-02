import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { HomeComponent } from './front-ui/components/home/home.component';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { AuthGuardService } from './admin/service/guard/auth-guard.service';

const routes: Routes = [
  //Admin Panel Kısmı
  {
    path: "admin",
    component: LayoutComponent,
    canActivate: [AuthGuardService],
    children: [
      { path: "", component: DashboardComponent },
      {
        path: "category",
        loadChildren: () => import("./admin/components/category/category.module")
          .then(m => m.CategoryModule)
      },
      {
        path: "user",
        loadChildren: () => import("./admin/components/user/user.module")
          .then(m => m.UserModule)
      },
    ]
  },

  //Front-UI Kısmı
  { path: "", component: HomeComponent },
  {
    path: "menu",
    loadChildren: () => import("./front-ui/components/menu/menu.module")
      .then(m => m.MenuModule)
  },
  {
    path: "login",
    loadChildren: () => import("./admin/components/user/user.module")
      .then(m => m.UserModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
