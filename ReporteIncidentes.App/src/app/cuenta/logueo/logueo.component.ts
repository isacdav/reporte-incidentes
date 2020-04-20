import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-logueo',
  templateUrl: './logueo.component.html',
  styleUrls: ['./logueo.component.css'],
})
export class LogueoComponent implements OnInit {
  errores: boolean = false;
  mensajeError: string = 'Ha ocurrido un error';
  mensajeRegistrado: string = '';

  inicioForm = this.fb.group({
    correoElectronico: ['', [Validators.required, Validators.email]],
    contrasena: ['', Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private usuarioSrv: UsuarioService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    if (!this.usuarioSrv.estaLogueado()) {
      this.router.navigate(['/incidencias']);
    }
  }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      if (params['registrado'] == 'exitoso') {
        this.mensajeRegistrado = 'Registro Exitoso. Por favor inicie sesión.';
      }
    });
  }

  loguear() {
    this.errores = false;

    if (!this.inicioForm.valid) {
      this.errores = true;
      return;
    }

    this.usuarioSrv.iniciarSesion(this.inicioForm.value).subscribe(
      (resp) => {
        if (resp.hayError) {
          this.errores = true;
          this.mensajeError = resp.mensajeError;
        }
        if (resp.objetoRespuesta == null) {
          this.errores = true;
          this.mensajeError = 'Credenciales incorrectas';
        } else {
          this.router.navigate(['/incidencias']);
        }
      },
      (errorResp) => {
        this.errores = true;
        this.mensajeError = errorResp.error.title;
      }
    );
  }
}
