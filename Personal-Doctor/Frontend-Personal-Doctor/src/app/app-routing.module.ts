import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { NaehwerteComponent } from './naehwerte/naehwerte.component';
import { RegestrierenComponent } from './regestrieren/regestrieren.component'
import { KalorienRechnerComponent } from './kalorien-rechner/kalorien-rechner.component';
import { MeinArztComponent } from './mein-arzt/mein-arzt.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent},
  { path: 'home', component: HomeComponent},
  { path: 'naehwerte', component: NaehwerteComponent},
  { path: 'regestrieren', component: RegestrierenComponent},
  {path: 'kalorienRechner', component: KalorienRechnerComponent},
  {path: 'MeinArzt', component: MeinArztComponent}
  
]


@NgModule({
  declarations: [],
  imports: [CommonModule,RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

