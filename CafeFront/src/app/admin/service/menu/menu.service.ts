import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MenuService {
  private apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) {}

//GetAll Menu Category
  getCategories(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Category/GetAll`);
  }
}
