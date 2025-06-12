import { Injectable } from '@angular/core';
import { Ksiazka } from '../models/ksiazka';
import { Observable, of } from 'rxjs';
import { KsiazkaBody } from '../models/ksiazka-body';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ListaService {
  private readonly baseURL = 'http://localhost:5006/api/Ksiazka'; 

  constructor(private httpClient: HttpClient) {}

  get(): Observable<Ksiazka[]> {
    return this.httpClient.get<Ksiazka[]>(this.baseURL);
  }

  getByID(id: number): Observable<Ksiazka> {
    const url = `${this.baseURL}/${id}`;
    return this.httpClient.get<Ksiazka>(url);
  }

  post(body: KsiazkaBody): Observable<void> {
    return this.httpClient.post<void>(this.baseURL, body);
  }

  put(id: number, body: KsiazkaBody): Observable<void> {
    const url = `${this.baseURL}/${id}`;
    return this.httpClient.put<void>(url, body);
  }

  delete(id: number): Observable<void> {
    const url = `${this.baseURL}/${id}`;
    return this.httpClient.delete<void>(url);
  }
}
