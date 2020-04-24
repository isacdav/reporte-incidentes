import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Server } from '../common/secret/server';

@Injectable({
  providedIn: 'root',
})
export class ReporteService {
  constructor(private http: HttpClient) {}

  public getReportes(): Observable<any> {
    return this.http.get(
      Server.api_url() + '/Incidencias/ConsultarIncidenciasUsuario'
    );
  }

  public getReportesUsuario(id: number): Observable<any> {
    return this.http.get(
      Server.api_url() +
        '/Incidencias/ConsultarIncidenciasUsuario?idUsuario=' +
        id
    );
  }

  public cambiarEstado(idInc: number, estado: string) {
    return this.http.post(
      Server.api_url() +
        '/Incidencias/CambiarEstadoIncidencia?idIncidencia=' +
        idInc +
        '&estado=' +
        estado,
      null
    );
  }
}
