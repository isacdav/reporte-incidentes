import { Component, OnInit, Input } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { ReporteService } from 'src/app/services/reporte.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-incidencia',
  templateUrl: './incidencia.component.html',
  styleUrls: ['./incidencia.component.css'],
})
export class IncidenciaComponent implements OnInit {
  @Input() incidenciaActual: any;

  lat: any;
  lng: any;

  esCreador: boolean = false;

  constructor(
    private usuarioSrv: UsuarioService,
    private reporteSrv: ReporteService,
    private modalService: NgbModal
  ) {}

  ngOnInit() {
    if (!this.usuarioSrv.estaLogueado()) {
      let idUsuario = this.usuarioSrv.getIdUsuario();
      this.esCreador = idUsuario == this.incidenciaActual.idUsuario;
    }

    this.lat = this.incidenciaActual.latitud;
    this.lng = this.incidenciaActual.longitud;
  }

  verImagenes() {
    alert('Funciona');
  }

  cambiarEstadoProgreso() {
    this.reporteSrv
      .cambiarEstado(this.incidenciaActual.idIncidencia, 'A')
      .subscribe(
        (resp: any) => {
          if (!resp.hayError) {
            this.incidenciaActual.estado = resp.objectoRespuesta.estado;
          }
        },
        () => {}
      );
  }

  cambiarEstadoFinalizado() {
    this.reporteSrv
      .cambiarEstado(this.incidenciaActual.idIncidencia, 'F')
      .subscribe(
        (resp: any) => {
          if (!resp.hayError) {
            this.incidenciaActual.estado = resp.objectoRespuesta.estado;
          }
        },
        () => {}
      );
  }

  open(content) {
    this.modalService
      .open(content, { ariaLabelledBy: 'modal-basic-title', size: 'xl' });
  }
}
