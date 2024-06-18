import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginService, UserLogin, Usuario } from './login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit{
  formulario: FormGroup;
  userControl: FormControl;
  passwordControl: FormControl;
  submitted = false;
  usuarioInvalido = false;

  usrLogin: UserLogin;
  usuario: Usuario;

  constructor(private formBuilder: FormBuilder, private loginService: LoginService) { }
  
  ngOnInit(): void {
    this.userControl = new FormControl('', Validators.required);
    this.passwordControl = new FormControl('', [Validators.required]);
    
    this.formulario = this.formBuilder.group({
      user: this.userControl, 
      password: this.passwordControl,
    });
  }

  saveData(): void{
    console.log(this.formulario.value);
    this.submitted = true;
    this.usuarioInvalido = false;

    if (this.formulario.valid) {
      this.postUsuario();  
    }
    //this.getUsuario();
  }

  getUsuario() {
    this.loginService.getLogin().subscribe((data: Usuario) => {
      this.usuario = data;
      console.log(this.usuario);
    });
  }

  postUsuario() {
    this.usrLogin = {
        user: '',
        password: ''
    }

    this.usrLogin.user = this.formulario.value.user;
    this.usrLogin.password = this.formulario.value.password;

    this.loginService.postLogin(this.usrLogin).subscribe((data: Usuario) => {
      this.usuario = data;
      console.log(this.usuario);

      if(this.usuario.usuario == null){
        this.usuarioInvalido = true;
      }
    });
  }
}
