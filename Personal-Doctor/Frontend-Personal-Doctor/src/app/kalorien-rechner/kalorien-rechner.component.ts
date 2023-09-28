import { Component} from '@angular/core';

@Component({
  selector: 'app-kalorien-rechner',
  templateUrl: './kalorien-rechner.component.html',
  styleUrls: ['./kalorien-rechner.component.css']
})
export class KalorienRechnerComponent {


  geschlecht: string = "";
  alter: number = NaN  ;
  groesse: number = NaN;
  gewicht: number = NaN;
  aktivitaet: string = "";
  sport : string = "";
  ziel : string = "";
  faktor: number = 0;
  bedarf: number = 0;

  Berechnung(){
    var gewicht_rechnung = 0;
    var grösse_rechnung = 0;
    var alter_rechnung = 0;
    var abnehmen = 0;

    if(this.geschlecht = "one"){
      gewicht_rechnung = 13.7;
      grösse_rechnung = 5;
      alter_rechnung = 6.8;
      abnehmen = 450;
      this.bedarf = 66.47;
    }else{
      gewicht_rechnung = 9.6;
      grösse_rechnung = 1.8;
      alter_rechnung = 4.7;
      abnehmen = 350;
      this.bedarf = 655.1;
    }

    this.bedarf = Math.round(this.bedarf + (gewicht_rechnung * this.gewicht) + (grösse_rechnung * this.groesse) + (alter_rechnung * this.alter));

    if(this.ziel = "one"){
      this.bedarf = this.bedarf - abnehmen;
    }else if (this.ziel = "two"){
      this.bedarf = this.bedarf;
    }else if(this.ziel = "three"){
      this.bedarf = this.bedarf + abnehmen;
    }


    if(this.aktivitaet = "one"){
      this.faktor = 1.2;
    }else if(this.aktivitaet = "two"){
      this.faktor = 1.4;
    }else if(this.aktivitaet = "three"){
      this.faktor = 1.6;
    }else if(this.aktivitaet = "four"){
      this.faktor = 1.8;
    }

    if(this.sport = "one"){
      this.faktor = this.faktor + 0.2;
    }else if(this.sport = "two"){
      this.faktor = this.faktor + 0.2;
    }else if(this.sport = "three"){
      this.faktor = this.faktor + 0.2;
    }else if(this.sport = "four"){
      this.faktor = this.faktor + 0.3;
    }else if(this.sport = "five"){
      this.faktor = this.faktor + 0.4;
    }else if(this.sport = "six"){
      this.faktor = this.faktor + 0.5;
    }

    this.bedarf = Math.round(this.bedarf * this.faktor)



  }


}
