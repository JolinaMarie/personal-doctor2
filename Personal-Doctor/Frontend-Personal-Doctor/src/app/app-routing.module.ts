import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NaehwerteComponent } from './naehwerte/naehwerte.component';
import { RegestrierenComponent } from './regestrieren/regestrieren.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: 'home', component: HomeComponent},
  { path: 'naehwerte', component: NaehwerteComponent},
  { path: 'regestrieren', component: RegestrierenComponent},
];

@NgModule({
  declarations: [],
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
