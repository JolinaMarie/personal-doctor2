import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MeinArztService {
  private baseUrl = 'http://192.168.178.36:5000';

  constructor(private http: HttpClient) { }

  getIllnesses(symptoms: string[]): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const body = { symptoms };

    return this.http.post(`${this.baseUrl}/get_illnesses`, body, { headers });
  }
}
