import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Naehrwert } from '../model/naehrwert.model';

@Injectable({
  providedIn: 'root'
})
export class NaehrwerteService {
  private baseUrl = 'https://localhost:7016';

  constructor(private httpClient: HttpClient) { }

  getAllNaehrwerte(): Observable<Naehrwert[]> {
    return this.httpClient.get<Naehrwert[]>(`${this.baseUrl}/api/naehrwerte/all`)
      .pipe(
        tap(data => console.log('Fetched data:', data)),
        catchError(error => {
          console.error('Error fetching data:', error);
          throw error;
        })
      );
  }

  getNaehrwertById(id: number): Observable<any> {
    return this.httpClient.get<Naehrwert[]>(`${this.baseUrl}/api/naehrwerte/${id}`);
  }
}