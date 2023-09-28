import { Component } from '@angular/core';
import { MeinArztService } from './mein-arzt.service';

@Component({
  selector: 'app-mein-arzt',
  templateUrl: './mein-arzt.component.html',
  styleUrls: ['./mein-arzt.component.css']
})
export class MeinArztComponent {
  selectedSymptoms: string[] = [];
  results: any = {};

  constructor(private meinArztService: MeinArztService) {}
  fetchIllnesses() {
    console.log('Selected Symptoms:', this.selectedSymptoms);
    this.meinArztService.getIllnesses(this.selectedSymptoms).subscribe(
      (response) => {
        console.log('API Response:', response);
        this.results = response;
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }
}
