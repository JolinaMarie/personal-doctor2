import { Component } from '@angular/core';

@Component({
  selector: 'app-bmi-rechner',
  templateUrl: './bmi-rechner.component.html',
  styleUrls: ['./bmi-rechner.component.css'],
})
export class BMIRechnerComponent {
  geschlecht: string = '';
  alter: number = 0;
  gewicht: number = 0;
  groesse: number = 0;
  BMI: number = 0;
  BMI_String: String = '';

  Berechnung() {
    var bmi_berechnung = 18;
    var groesse_rechnung = this.groesse / 100;

    if(this.geschlecht == "one"){
      bmi_berechnung = bmi_berechnung+1;
    }else{
      bmi_berechnung = bmi_berechnung;
    }

    

    this.BMI = Math.round(this.gewicht / (groesse_rechnung * groesse_rechnung));

    //Alters Überprüfung zum BMI

    if (this.alter <= 24) {
      bmi_berechnung = bmi_berechnung ;
    } else if (this.alter <= 34) {
      bmi_berechnung = bmi_berechnung + 1;
    } else if (this.alter <= 44) {
      bmi_berechnung = bmi_berechnung + 2;
    } else if (this.alter <= 54) {
      bmi_berechnung = bmi_berechnung + 3;
    } else if (this.alter <= 64) {
      bmi_berechnung = bmi_berechnung + 4;
    } else if (this.alter >= 64) {
      bmi_berechnung = bmi_berechnung + 5;
    }

    if (this.BMI < bmi_berechnung) {
      this.BMI_String = 'Untergewicht';
    } else if (this.BMI <= bmi_berechnung + 6) {
      this.BMI_String = 'Normalgewicht';
    } else if (this.BMI <= bmi_berechnung + 11) {
      this.BMI_String = 'Übergewicht';
    } else if (this.BMI <= bmi_berechnung + 21) {
      this.BMI_String = 'Adipositas';
    } else if (this.BMI > bmi_berechnung + 21) {
      this.BMI_String = 'starke Adipositas';
    }
  }
}
