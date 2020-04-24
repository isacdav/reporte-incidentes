import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/Rx';
import { Server } from '../common/secret/server';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  constructor(private http: HttpClient) {}

  private guardarInfo(data: any) {
    if (data.objetoRespuesta != null) {
      localStorage.setItem('idUsuario', data.objetoRespuesta.idUsuario);
      localStorage.setItem(
        'nombre',
        data.objetoRespuesta.nombre + ' ' + data.objetoRespuesta.apellidos
      );
    }
    return data;
  }

  public registrar(userData: any): Observable<any> {
    return this.http.post(
      Server.api_url() + '/Usuarios/InsertarUsuario',
      userData
    );
  }

  public iniciarSesion(data: any): Observable<any> {
    return this.http
      .post(
        Server.api_url() +
          '/Usuarios/LogIn?correoElectronico=' +
          data.correoElectronico +
          '&contrasena=' +
          data.contrasena,
        null
      )
      .map((data) => this.guardarInfo(data));
  }

  public cerrarSesion() {
    localStorage.removeItem('idUsuario');
    localStorage.removeItem('nombre');
  }

  public estaLogueado(): boolean {
    return localStorage.getItem('idUsuario') === null;
  }

  public getNombre(): string {
    return localStorage.getItem('nombre');
  }

  public getIdUsuario(): any {
    return localStorage.getItem('idUsuario');
  }
}
