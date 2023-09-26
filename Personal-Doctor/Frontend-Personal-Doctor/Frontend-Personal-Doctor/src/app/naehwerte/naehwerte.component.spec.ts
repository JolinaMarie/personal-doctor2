import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NaehwerteComponent } from './naehwerte.component';

describe('NaehwerteComponent', () => {
  let component: NaehwerteComponent;
  let fixture: ComponentFixture<NaehwerteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NaehwerteComponent]
    });
    fixture = TestBed.createComponent(NaehwerteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
