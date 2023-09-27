import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KalorienRechnerComponent } from './kalorien-rechner.component';

describe('KalorienRechnerComponent', () => {
  let component: KalorienRechnerComponent;
  let fixture: ComponentFixture<KalorienRechnerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [KalorienRechnerComponent]
    });
    fixture = TestBed.createComponent(KalorienRechnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
