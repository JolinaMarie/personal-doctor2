import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../model/user.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private baseUrl = 'https://localhost:7016';
  constructor(private http: HttpClient) { }

  // loginUser(user: User): Observable<any> {
  //   return this.http.post(`${this.baseUrl}/api/sessions/login`, user);
  // }

  loginUser(user: User): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const requestOptions = {
      headers: headers,
      responseType: 'text' as 'json'
    };

    return this.http.post(`${this.baseUrl}/api/sessions/login`, user, requestOptions);
  }
}