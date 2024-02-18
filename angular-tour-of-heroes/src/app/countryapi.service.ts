import { Injectable } from '@angular/core';
import { Country } from './model/country';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CountryapiService {


  private apiUrl = 'http://localhost:5191/'; // Replace with your actual API URL

  constructor(private http: HttpClient) { }

  addCountry(country: Country): Observable<Country> {
    
    return this.http.post<Country>('http://localhost:5191/api/Country', country);
  }
}
