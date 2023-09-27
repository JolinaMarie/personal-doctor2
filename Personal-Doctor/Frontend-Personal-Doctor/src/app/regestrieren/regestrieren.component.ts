import { Component, OnInit } from '@angular/core';
import { RegestrierenService } from './regestrieren.service';
import { User } from '../model/user.model';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  user: User = new User();

  constructor(private registerUserService : RegestrierenService, private router: Router, private _snackBar: MatSnackBar) { }

  registerUser() {
    if (!this.user.areFieldsEmpty()) {
      if (this.user.password === this.user.confirmPassword && this.user.email === this.user.confirmEmail) {
        this.registerUserService.addUser(this.user).subscribe(
          (response: any) => {
            console.log('User registration successful', response);
            this.user.clearFields();

            this._snackBar.open('Benutzer erfolgreich Registriert', 'Close', {
              duration: 3000,
            });
  
            setTimeout(() => {
              this.router.navigate(['/login']);
            }, 3000);
          },
          (error) => {
            console.error('Registration failed', error);
            if (error instanceof HttpErrorResponse && error.status === 409) {
              this.errorMessage = 'Die E-Mail-Adresse ist bereits registriert.';
            } else {
              this.errorMessage = 'Registrierung fehlgeschlagen, bitte versuchen Sie es erneut: ' + error.message;
            }
          }
        );
      } else {
        console.error('Passwords or Emails do not match');
        this.errorMessage = 'Passwort oder E-mail stimmen nicht überein';
      }
    } else {
      console.error('Fields are empty');
      this.errorMessage = 'Bitte füllen Sie alle Felder aus.';
    }
  }
  
}