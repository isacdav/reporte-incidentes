import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(public usuarioSrv: UsuarioService, private router: Router) { }

  ngOnInit() {
  }

  cerrar() {
    this.usuarioSrv.cerrarSesion();
    this.router.navigate(['/loguearse']);
  }

}
