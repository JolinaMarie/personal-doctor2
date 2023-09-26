import { Component, OnInit } from '@angular/core';
import { RegestrierenService } from './regestrieren.service';
import { User } from '../model/user.model';

@Component({
  selector: 'app-regestrieren',
  templateUrl: './regestrieren.component.html',
  styleUrls: ['./regestrieren.component.css']
})
export class RegestrierenComponent{
  hide = true;
  hidePassword: boolean = true; 
  hidePasswordConfirmation: boolean = true; 
  errorMessage: string = ''; // Initialize an error message variable
  getAllUsers: any[] = [];
  createUser: User = new User();

  constructor(private registerUserService : RegestrierenService) { }

  registerUser() {
    // Check if passwords match before sending the request (you may need additional validation)
    if (this.createUser.password === this.createUser.confirmPassword) {
      this.registerUserService.addUser(this.createUser).subscribe((response: any) => {
        // Handle successful registration (e.g., display a success message or navigate to a login page)
        console.log('User registration successful', response);
      }, error => {
        // Handle registration failure (e.g., display an error message)
        console.error('User registration failed', error);
        this.errorMessage = 'Registration failed: ' + error.message; // Set error message
      });
    } else {
      // Handle password mismatch (e.g., show an error message)
      console.error('Passwords do not match');
      this.errorMessage = 'Passwords do not match'; // Handle password mismatch
    }
  }
}
