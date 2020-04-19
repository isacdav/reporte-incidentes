import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  public register(userData: any): Observable<any> {
    return this.http.post('https://reporteincidenciasapi.azurewebsites.net/api/Usuarios/InsertarUsuario', userData);
  }

}
