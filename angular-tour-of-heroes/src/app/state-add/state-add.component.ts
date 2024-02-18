import { Component } from '@angular/core';
import { State } from '../model/state';
import { Country } from '../model/country';
import { ApiService } from '../apiservice.service';
@Component({
  selector: 'app-state-add',
  templateUrl: './state-add.component.html',
  styleUrls: ['./state-add.component.css']
})
export class StateAddComponent {

  state: State = {stateId:0, stateName: '', countryName: '',countryId:0 }; // Assuming you have a dropdown/select to select the country
  countries: Country[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
   
    
    this.getCountries();
  }

  getCountries(): void {
    
    this.apiService.getCountries()
      .subscribe(countries => this.countries = countries);
  }

  
  addState(): void {
    
    this.apiService.addState(this.state)
      .subscribe(() => {
        // Handle success
        console.log('State added successfully');
       
      }, error => {
        // Handle error
        console.error('Error adding state:', error);
      });
  }
}
