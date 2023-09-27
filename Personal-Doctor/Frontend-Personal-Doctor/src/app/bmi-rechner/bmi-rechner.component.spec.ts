import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BMIRechnerComponent } from './bmi-rechner.component';

describe('BMIRechnerComponent', () => {
  let component: BMIRechnerComponent;
  let fixture: ComponentFixture<BMIRechnerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BMIRechnerComponent]
    });
    fixture = TestBed.createComponent(BMIRechnerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
