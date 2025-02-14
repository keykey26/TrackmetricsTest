import { formatCurrency } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

interface FormReturn {
  Value: number;
}

@Component({
  selector: 'app-currency-conversion-form',
  standalone: false,
  templateUrl: './currency-conversion-form.component.html',
  styleUrl: './currency-conversion-form.component.css'
})
export class CurrencyConversionFormComponent {
  constructor(private http: HttpClient) {}

  baseValue = new FormControl(0);
  convertTo = new FormControl('USD');
  convertedValue = 0;  
  formReturn:any;
  valueReturn:boolean  = false;

  submitForm() { 
    this.http.post<FormReturn>('https://localhost:7234/CurrencyConversionApi', {ConvertTo: this.convertTo.value, BaseValue: this.baseValue.value}).subscribe(
      (result) => {
        console.log(result);
        this.formReturn = result;
        this.valueReturn = true;
      },
      (error) => {
        console.error(error);
      }
    );
   }
}
