import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { server, API } from '../environments/environments'
import { Observable } from 'rxjs';

export interface UserLogin{
  user: string;
  password: string;
}

export interface Usuario{
    usuario: string;
    clave: string;
    nombre1: string;
    nombre2: string;
    apellido1: string;
    apellido2: string;
    rut: string;
    email: string;
    sexo: string;
    idEstado: number;
    idPerfil: number;
    empresa: string
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private configUrl: string;

  constructor(private http: HttpClient) { }

  getLogin(): Observable<Usuario>{
    this.configUrl = server.url + API.login.login;
    const usr = this.http.get<Usuario>(this.configUrl);
    return usr;
  }

  postLogin(usrLogin : UserLogin): Observable<Usuario>{
    this.configUrl = server.url + API.login.login;
    const usr = this.http.post<Usuario>(this.configUrl, usrLogin);
    return usr;
  }
}
