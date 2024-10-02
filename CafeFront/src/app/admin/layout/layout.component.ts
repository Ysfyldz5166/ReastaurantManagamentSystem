import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent {

  isSidebarActive = false;

  constructor(private router: Router) {}

  toggleSidebar() {
    this.isSidebarActive = !this.isSidebarActive;
  }

  logout() {
    localStorage.removeItem('userId'); // localStorage'dan userId'yi temizle
    this.router.navigate(['/login']); // Login sayfasına yönlendir
  }
}
