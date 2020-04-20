import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nueva',
  templateUrl: './nueva.component.html',
  styleUrls: ['./nueva.component.css'],
})
export class NuevaComponent implements OnInit {
  name = 'Mapa';
  lat: any;
  lng: any;

  constructor(public usuarioSrv: UsuarioService, private router: Router) {
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

  ngOnInit() {}
}
