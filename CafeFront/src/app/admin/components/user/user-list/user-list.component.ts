import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from './user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  users: any[] = [];
  isLoading: boolean = true;

  constructor(private userService: UserService, private router: Router) {}

  ngOnInit() {
    this.userService.getAllUsers().subscribe(
      (data: any[]) => {
        this.users = data;
        this.isLoading = false;
      },
      (error: any) => {
        console.error('Error fetching users', error);
        this.isLoading = false;
      }
    );
  }

  // Yeni kullanıcı ekleme sayfasına yönlendir
  navigateToAddUser() {
    this.router.navigate(['admin/user/manage-user/:id']);
  }

  // Kullanıcı düzenleme sayfasına yönlendir
  editUser(id: number) {
    this.router.navigate(['admin/user/manage-user', id]);
  }

  // Kullanıcıyı sil
  deleteUser(id: number) {
    if (confirm('Bu kullanıcıyı silmek istediğinizden emin misiniz?')) {
      this.userService.deleteUser(id).subscribe(
        () => {
          this.users = this.users.filter(user => user.id !== id);
        },
        (error: any) => {
          console.error('Error deleting user', error);
        }
      );
    }
  }
}
