import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user-list/user.service';

@Component({
  selector: 'app-user-manage',
  templateUrl: './user-manage.component.html',
  styleUrls: ['./user-manage.component.scss']
})
export class UserManageComponent implements OnInit {
  userForm: FormGroup; // Form grubu
  isEditing: boolean = false;
  isLoading: boolean = true;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    // Formu oluştur
    this.userForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      role: ['', Validators.required],
      password: ['', Validators.required], // Şifre alanı
    });
  }

  ngOnInit(): void {
    const userId = this.route.snapshot.paramMap.get('id');
    if (userId) {
      this.isEditing = true;
      this.userService.getUserById(userId).subscribe({
        next: (data: any) => {
          // Formu mevcut kullanıcı verileri ile doldur
          this.userForm.patchValue({
            username: data.username,
            email: data.email,
            role: data.role,
            password: '', // Şifreyi boş bırak
          });
          this.isLoading = false;
        },
        error: () => {
          this.isLoading = false;
        }
      });
    } else {
      this.isEditing = false;
      this.isLoading = false;
    }
  }

  saveUser(): void {
    if (this.userForm.valid) {
      const userData = {
        id: this.route.snapshot.paramMap.get('id'), // Kullanıcı ID'sini al
        ...this.userForm.value // Formdan gelen verileri al
      };

      if (this.isEditing) {
        console.log("Güncellenen Kullanıcı:", userData);

        this.userService.updateUser(userData).subscribe({
          next: () => {
            console.log("Güncellenen Kullanıcı:", userData);
            this.router.navigate(['/admin/user/list']);  // Kullanıcı listeleme sayfasına yönlendirme
          },
          error: () => {
            // Hata yönetimi
          }
        });
      } else {
        this.userService.createUser(userData).subscribe({
          next: () => {
            this.router.navigate(['/admin/user/list']);  // Yeni kullanıcı eklendikten sonra yönlendirme
          },
          error: () => {
            // Hata yönetimi
          }
        });
      }
    } else {
      console.log("Form geçersiz"); // Form geçerli değilse
    }
  }

  cancel(): void {
    this.router.navigate(['/admin/user/list']);  // İptal durumunda geri yönlendirme
  }
}
