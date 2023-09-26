import { Component, OnInit } from '@angular/core';
import { User } from '../model/user.model';
import { LoginService } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{
  hide = true;
  user: User = new User();
  errorMessage: string = '';
  constructor(private loginService: LoginService) { }

  loginUser() {
    if (!this.user.email || !this.user.password) {
      this.errorMessage = 'Es müssen beide Felder ausgefüllt sein!';
      return;
    }

    this.loginService.loginUser(this.user).subscribe(
      (response: any) => {
        console.log('User login successful', response);
      },
      (error) => {
        console.error('User login failed', error);
        this.errorMessage = 'Login failed: ' + error.message;

        // Password Feld wird nach dem Fehlerhaften einloggen leer gemacht
        this.user.password = '';
      }
    );
  }
}
