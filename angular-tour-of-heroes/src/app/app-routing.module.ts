import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CountryComponent } from './country/country.component';
import { StateAddComponent } from './state-add/state-add.component';
const routes: Routes = [
 
  // {redirectTo:'',path:'login', pathMatch:'full'},
  
  //  {path:'/', component:CountryComponent},
   {path:'ADDSTATE', component:StateAddComponent},
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
