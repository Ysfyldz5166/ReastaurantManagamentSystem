import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent {
  email: string = '';  // Kullanıcı adı için tanımlama
  password: string = '';  // Şifre için tanımlama


  constructor(private authService: AuthService, private router: Router) {}

  onLogin(form: NgForm) {
    const { email, password } = form.value; 
    console.log("gönderilen veri", form.value);
    

    this.authService.login(email, password).subscribe(
      (response) => {
        localStorage.setItem('userId', response.id); 
        this.router.navigate(['/admin']); 
      },
      (error) => {
        console.error('Giriş başarısız:', error);
      }
    );
  }


}
