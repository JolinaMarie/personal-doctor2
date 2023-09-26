import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegestrierenComponent } from './regestrieren.component';

describe('RegestrierenComponent', () => {
  let component: RegestrierenComponent;
  let fixture: ComponentFixture<RegestrierenComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RegestrierenComponent]
    });
    fixture = TestBed.createComponent(RegestrierenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
