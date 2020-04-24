import { Injectable } from '@angular/core';
import {
  CanActivate,
  Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { UsuarioService } from './usuario.service';

@Injectable()
export class IncidenciaGuard implements CanActivate {
  private url: string;

  constructor(private usuarioSrv: UsuarioService, private router: Router) {}

  private irAListado(): boolean {
    this.router.navigate(['/incidencias']);
    return false;
  }

  private esMisReportes(): boolean {
    if (this.url.includes('misreportes')) return true;
    return false;
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    this.url = state.url;
    if (!this.usuarioSrv.estaLogueado() && this.esMisReportes())
      return true;
    return this.irAListado();
  }
}
