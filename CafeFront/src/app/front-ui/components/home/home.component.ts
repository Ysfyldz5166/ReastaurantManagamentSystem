import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  @ViewChild('menuSection') menuSection!: ElementRef;
  menuActive = false;

  toggleMenu() {
    this.menuActive = !this.menuActive;
  }

  scrollToMenu() {
    document.querySelector('.menu')?.scrollIntoView({ behavior: 'smooth' });
  }

}
