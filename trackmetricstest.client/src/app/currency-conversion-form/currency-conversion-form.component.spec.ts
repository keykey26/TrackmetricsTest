import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrencyConversionFormComponent } from './currency-conversion-form.component';

describe('CurrencyConversionFormComponent', () => {
  let component: CurrencyConversionFormComponent;
  let fixture: ComponentFixture<CurrencyConversionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CurrencyConversionFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CurrencyConversionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
