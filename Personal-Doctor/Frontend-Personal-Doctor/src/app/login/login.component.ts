import { Component, OnInit } from '@angular/core';
import { User } from '../model/user.model';
import { LoginService } from './login.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { SessionService } from '../service/session.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  hide = true;
  user: User = new User();
  errorMessage: string = '';
  constructor(private loginService: LoginService, private router: Router, private sessionService: SessionService, private _snackBar: MatSnackBar ) { }


  loginUser() {
    if (!this.user.email || !this.user.password) {
      this.errorMessage = 'Es müssen beide Felder ausgefüllt sein!';
      return;
    }
    console.log('Email:', this.user.email);
    console.log('Password:', this.user.password);

    this.loginService.loginUser(this.user).subscribe(
      (response: any) => {
        console.log('User login successful', response);

        

        const sessionKey = response;
        this.sessionService.setSessionKey(sessionKey);
      
        this._snackBar.open('Erfolgreich angemeldet', 'Close', {
          duration: 2000,
        });

        this.router.navigate(['/home'])
      },

      (error) => {
        console.error('User login failed', error);
        if (error.status === 401) {
          this.errorMessage = 'Anmeldung fehlgeschlagen: Ungültige E-Mail oder Passwort';
        } else {
          this.errorMessage = 'Login failed: An error occurred. Please try again later.';
        }
        this.user.password = '';
      }
    );
  }
}
