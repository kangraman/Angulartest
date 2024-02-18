import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
 import { FormsModule } from '@angular/forms';
import { CountryComponent } from './country/country.component';
import { StateAddComponent } from './state-add/state-add.component';
import { ApiService } from './apiservice.service';
import { CountryapiService } from './countryapi.service';
import { HttpClientModule } from '@angular/common/http';
import { HttpClient, HttpHandler, HttpBackend, XhrFactory } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    CountryComponent,
    StateAddComponent,
  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ToastrModule,
    HttpClientModule
  ],
   providers: [
    ApiService,CountryapiService,
    { provide: HttpClient, useClass: HttpClient,
      deps: [HttpBackend, XhrFactory] },
  ],
 
  bootstrap: [AppComponent]
  
})
export class AppModule { }
