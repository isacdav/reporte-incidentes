import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IncidenciasService {

  constructor(private http: HttpClient) { }

  public provincias(){
    return this.http.get('https://ubicaciones.paginasweb.cr/provincias.json').toPromise();
  }

  public cantones(idProvincia:any){
    return this.http.get('https://ubicaciones.paginasweb.cr/provincia/'+idProvincia+'/cantones.json').toPromise();
  }

  public distritos(idProvincia:any,idDistritos:any){
    return this.http.get('https://ubicaciones.paginasweb.cr/provincia/'+idProvincia+'/canton/'+idDistritos+'/distritos.json').toPromise();
  }

  public registrar(incidenciasData: any): Observable<any> {
    return this.http.post(
      'https://reporteincidencias.azurewebsites.net//api/Incidencias/InsertarIncidencias',
      incidenciasData
    );
  }

  public imageUploader(formData:FormData):Observable<any>{
    return this.http.post('https://reporteincidencias.azurewebsites.net/api/Upload',formData);
  }

}