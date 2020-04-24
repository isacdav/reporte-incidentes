import { Component, OnInit } from '@angular/core';
import { ReporteService } from 'src/app/services/reporte.service';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styleUrls: ['./listado.component.css'],
})
export class ListadoComponent implements OnInit {
  constructor(
    private reporteSrv: ReporteService,
    private router: Router,
    private usuarioSrv: UsuarioService
  ) {}

  incidencias: any[] = [];
  url: string;
  idUsuario: number;

  ngOnInit() {
    this.url = this.router.url;
    
    if (!this.usuarioSrv.estaLogueado())
      this.idUsuario = this.usuarioSrv.getIdUsuario();

    if (this.url.includes('misreportes')) {
      const misReportesObservable = this.reporteSrv.getReportesUsuario(
        this.idUsuario
      );
      misReportesObservable.subscribe(
        (resp) => {
          this.incidencias = resp.objetoRespuesta;
        },
        (err) => {}
      );
    } else {
      const incidenciasObservable = this.reporteSrv.getReportes();
      incidenciasObservable.subscribe(
        (resp) => {
          this.incidencias = resp.objetoRespuesta;
        },
        (err) => {}
      );
    }
  }
}
