import { Component, OnInit } from '@angular/core';
import { User } from '../model/user.model';
import { LoginService } from './login.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  hide = true;
  user: User = new User();
  errorMessage: string = '';
  constructor(private loginService: LoginService, private formbuilder: FormBuilder, private router: Router) { }


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
        this.router.navigate(['/login']);
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
