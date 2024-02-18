import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { State } from './model/state';
import { Country } from './model/country';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:5191/';

  constructor(private http: HttpClient) {}
  
  addState(state: State): Observable<State> {
    alert(state.stateName)
    return this.http.post<State>('http://localhost:5191/api/State', state);
  }

  getCountries(): Observable<Country[]> {
    
    return this.http.get<Country[]>('http://localhost:5191/api/Country');
  }
}