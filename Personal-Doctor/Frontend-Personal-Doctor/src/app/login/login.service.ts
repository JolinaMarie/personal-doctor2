import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../model/user.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private baseUrl = 'https://localhost:7016';
  constructor(private http: HttpClient) { }

  loginUser(user: User): Observable<any> {
    // Implement user login logic and send an HTTP POST request
    const httpOptions = {
      headers: {
        'Content-Type': 'application/json'
      }
    };
    return this.http.post(`${this.baseUrl}/api/login`, user, httpOptions);
  }
}