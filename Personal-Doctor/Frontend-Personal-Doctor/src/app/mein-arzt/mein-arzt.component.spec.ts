import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MeinArztComponent } from './mein-arzt.component';

describe('MeinArztComponent', () => {
  let component: MeinArztComponent;
  let fixture: ComponentFixture<MeinArztComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MeinArztComponent]
    });
    fixture = TestBed.createComponent(MeinArztComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
