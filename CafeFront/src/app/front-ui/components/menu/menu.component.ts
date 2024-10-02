import { Component } from '@angular/core';
import { MenuService } from 'src/app/admin/service/menu/menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

  categories: any[] = [];

  constructor(private menuService: MenuService) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
    this.menuService.getCategories().subscribe(
      (data) => {
        
        this.categories = data;
        
        console.log("Gelen veri: ",this.categories);

      },
      (error) => {
        console.error('Error fetching categories', error);
      }
    );
  }

}
