import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
   // Assume you have a user object with a 'role' property
   private user: any = {};

   constructor() {}
 
   login(user: any) {
    console.log('p'+ this.user);
     this.user = user;
   }
 
   isAdmin(): boolean { 
    console.log('op:' + this.user!=null && this.user.fname == 'admin' ? true:false);
     return (this.user!=null && this.user.fname == 'admin' ? true:false);
     //return false;
   }

   isAuthenticated(): boolean {
    return !!this.user; // Assuming user is authenticated if user object is not empty
  }

  isUserSeller(): boolean {
    return this.user && this.user.fname === 'admin';
  }
}