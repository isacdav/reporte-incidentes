import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';
import { IncidenciasService } from 'src/app/services/Incidencias.servic';

@Component({
  selector: 'app-nueva',
  templateUrl: './nueva.component.html',
  styleUrls: ['./nueva.component.css'],
})
export class NuevaComponent implements OnInit {
  name = 'Mapa';
  lat: any;
  lng: any;
  provincias=[];
  cantones=[];
  distritos=[];
  idProvincia=0;
  constructor(public usuarioSrv: UsuarioService, private router: Router,private _incidenciasService:IncidenciasService) {
    if (this.usuarioSrv.estaLogueado()) {
      this.router.navigate(['/loguearse']);
    }

    if (navigator) {
      navigator.geolocation.getCurrentPosition((pos) => {
        this.lng = +pos.coords.longitude;
        this.lat = +pos.coords.latitude;
      });
    }
  }

  async getProvincias(){
    var resultados=await this._incidenciasService.provincias();
    for(let index in resultados){
      let provincia={
        id:+index,
        descripcion:resultados[index]
      }
      this.provincias.push(provincia);
    }    
  }

  async getCantones(idProvincia:any){
    this.cantones=[];
    var resultados= await this._incidenciasService.cantones(idProvincia);
    for(let index in resultados){
      let canton={
        id:+index,
        descripcion:resultados[index]
      }
      this.cantones.push(canton);
    }
  }

  async getDistritos(idProvincia:any,idCanton:any){
    this.distritos=[];
    var resultados=await this._incidenciasService.distritos(idProvincia,idCanton);
    for(let index in resultados){
      let distrito={
        id:+index,
        descripcion:resultados[index]
      }
      this.distritos.push(distrito);
    }
  }

    onOptionsSelectedProvincia(event:any){
      this.idProvincia=event.target.value;
      this.getCantones(event.target.value);
  }

  onOptionsSelectedCantones(event:any){
    this.getDistritos(this.idProvincia,event.target.value);
  }

   InicializarCombos(){
    this.getProvincias();
    this.getCantones(1);
    this.getDistritos(1,1);
   }

  ngOnInit() {
    this.InicializarCombos();
  }
}
