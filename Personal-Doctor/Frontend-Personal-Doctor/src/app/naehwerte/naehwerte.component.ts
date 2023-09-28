import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { NaehrwerteService } from './naehrwerte.service';
import { Naehrwert } from '../model/naehrwert.model';

@Component({
  selector: 'app-naehwerte',
  templateUrl: './naehwerte.component.html',
  styleUrls: ['./naehwerte.component.css']
})

export class NaehrwerteComponent implements OnInit {
  dataSource = new MatTableDataSource<Naehrwert>();
  displayedColumns: string[] = ['nahrungID', 'essen', 'brennwert', 'proteingehalt', 'kohlenhydrate', 'zucker', 'fett'];

  constructor(private naehrwertService: NaehrwerteService) { }

  ngOnInit() {
    this.naehrwertService.getAllNaehrwerte().subscribe((data: Naehrwert[]) => {
      this.dataSource.data = data;
    });
  }
}


