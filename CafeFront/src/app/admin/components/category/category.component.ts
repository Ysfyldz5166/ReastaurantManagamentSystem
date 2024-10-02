import { Component } from '@angular/core';
import { MenuService } from '../../service/menu/menu.service';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent {
  categories: any[] = [];

  constructor(private menuService: MenuService) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories() {
    this.menuService.getCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.error('Error fetching categories', error);
      }
    );
  }


}
