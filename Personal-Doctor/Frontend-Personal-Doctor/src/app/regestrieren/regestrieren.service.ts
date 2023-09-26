import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../model/user.model';

@Injectable({
  providedIn: 'root'
})
export class RegestrierenService {
  private baseUrl = 'https://localhost:7016';
  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get(`${this.baseUrl}/api/users/all`);
  } 

  addUser(user: User) {
    return this.http.post(`${this.baseUrl}/api/users`, user);
  }
}
