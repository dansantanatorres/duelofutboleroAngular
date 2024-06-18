import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  formulario: FormGroup;
  nombreControl: FormControl;
  emailControl: FormControl;
  telefonoControl: FormControl;
  submitted = false;

  constructor(private formBuilder: FormBuilder) { }
  
  ngOnInit(): void {
    this.nombreControl = new FormControl('', Validators.required);
    this.emailControl = new FormControl('', [Validators.required, Validators.email]);
    this.telefonoControl = new FormControl('', Validators.pattern('[0-9]{10}'));
    
    this.formulario = this.formBuilder.group({
      nombre: this.nombreControl, 
      email: this.emailControl,
      telefono: this.telefonoControl, 
    });
  }

  /*
  get f(): { [key: string]: AbstractControl } {
    return this.formulario.controls;
  }
  */

  saveData(): void{
    console.log(this.formulario.value);
    this.submitted = true;
  }

}
