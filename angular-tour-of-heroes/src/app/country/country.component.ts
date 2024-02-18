import { Component } from '@angular/core';
import { Country } from '../model/country';
import { CountryapiService } from '../countryapi.service';
import { HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-country',
  templateUrl: './country.component.html',
  styleUrls: ['./country.component.css']
})
export class CountryComponent {
  country: Country = { countryId:0,countryName: '' };

  constructor(private apiService: CountryapiService) { }

  addCountry(): void {
    
    this.apiService.addCountry(this.country)
      .subscribe(() => {
        // Handle success
        console.log('Country added successfully');
        // Optionally, you can reset the form or perform other actions
        this.country = { countryId:0,countryName: '' };
      }, error => {
        // Handle error
        console.error('Error adding country:', error);
      });
  }
}
