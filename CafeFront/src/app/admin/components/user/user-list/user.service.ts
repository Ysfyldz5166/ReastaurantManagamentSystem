import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiUrl: string = environment.apiUrl;

  constructor(private http: HttpClient) {}

  // Tüm kullanıcıları getir
  getAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/User/GetAll`);
  }

  // Kullanıcıyı ID ile getir
  getUserById(id: string): Observable<any> {
    return this.http.get< any>(`${this.apiUrl}/User/?Id=${id}`);
  }

  // Kullanıcıyı güncelle
  updateUser(user: any): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/User/Update`, user);
  }

  // Yeni kullanıcı oluştur
  createUser(user: any): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/User`, user);
  }

  // Kullanıcıyı sil
  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/User/${id}`);
  }
}
