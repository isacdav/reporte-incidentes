import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';
import { IncidenciasService } from 'src/app/services/Incidencias.servic';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-nueva',
  templateUrl: './nueva.component.html',
  styleUrls: ['./nueva.component.css'],
})
export class NuevaComponent implements OnInit {
  errores: boolean = false;
  mensajeError: string = 'Ha ocurrido un error';
  exito: boolean = false;
  mensajeExito: string = 'Datos ingresados correctamente';
  name = 'Mapa';
  lat: any;
  lng: any;
  provincias=[];
  cantones=[];
  distritos=[];
  idProvincia=0;
  registroForm=this.fb.group({
    idIncidencia:[],
    idUsuario:[],
    categoria:['', Validators.required],
    empresa:['', Validators.required],
    provincia:['', Validators.required],
    canton:['', Validators.required],
    distrito:['', Validators.required],
    direccionExacta:[
      '',
      [
        Validators.required,
        Validators.maxLength(500),
      ],
    ],
    latitud: [],
    longitud: [],
    rutaImagen1: [],
    rutaImagen2: [],
    rutaImagen3: [],
    rutaImagen4: [],
    detalleIncidencia: [
      '',
      [
        Validators.required,
        Validators.maxLength(500),
      ],
    ],
    estado: []
  });
  constructor(
      public usuarioSrv: UsuarioService, 
      private router: Router,
      private _incidenciasService:IncidenciasService,
      private fb: FormBuilder,) {
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

  guardarIncidencia(){
    this.errores = false;
    this.registroForm.controls['idIncidencia'].setValue(0);
    this.registroForm.controls['idUsuario'].setValue(localStorage.getItem('idUsuario'));
    this.registroForm.controls['estado'].setValue(0);
    this.registroForm.controls['latitud'].setValue(this.lat);
    this.registroForm.controls['longitud'].setValue(this.lng);
    this.registroForm.controls['rutaImagen1'].setValue('');
    this.registroForm.controls['rutaImagen2'].setValue('');
    this.registroForm.controls['rutaImagen3'].setValue('');
    this.registroForm.controls['rutaImagen4'].setValue('');
    if (!this.registroForm.valid) {
      this.errores = true;
      this.mensajeError = 'Favor revisar el formulario. No es válido.';
      return;
    }

    this._incidenciasService.registrar(this.registroForm.value).subscribe(
      (resp) => {
        if (resp.hayError) {
          this.errores = true;
          this.mensajeError = resp.mensajeError;
        } else {
          this.exito = true;
          this.mensajeExito = 'Incidencia ingresada correctamente';
        }
      },
      (errorResp) => {
        this.errores = true;
        this.mensajeError = errorResp.error.title;
      }
    );
  }
}
