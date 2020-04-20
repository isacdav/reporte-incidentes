import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css'],
})
export class RegistrarComponent implements OnInit {
  errores: boolean = false;
  mensajeError: string = 'Ha ocurrido un error';

  registroForm = this.fb.group({
    idUsuario: [],
    estadoUsuario: [],
    codigoActivacion: [],
    cedula: [
      '',
      [
        Validators.required,
        Validators.minLength(9),
        Validators.maxLength(9),
        Validators.pattern('[0-9]*'),
      ],
    ],
    nombre: ['', Validators.required],
    apellidos: ['', Validators.required],
    correoElectronico: ['', [Validators.required, Validators.email]],
    contrasena: [
      '',
      [
        Validators.required,
        Validators.pattern(
          '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[A-Za-z0-9$@$!#%*?&].{5,}'
        ),
      ],
    ],
    telefono: [
      '',
      [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(8),
        Validators.pattern('[6,7,8][0-9]*'),
      ],
    ],
    provincia: ['', Validators.required],
    direccion: ['', Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private usuarioSrv: UsuarioService,
    private router: Router
  ) {}

  ngOnInit() {}

  guardar() {
    this.errores = false;

    this.registroForm.controls['idUsuario'].setValue(0);
    this.registroForm.controls['estadoUsuario'].setValue(0);
    this.registroForm.controls['codigoActivacion'].setValue(0);

    if (!this.registroForm.valid) {
      this.errores = true;
      this.mensajeError = 'Favor revisar el formulario. No es válido.';
      return;
    }

    this.usuarioSrv.registrar(this.registroForm.value).subscribe(
      (resp) => {
        if (resp.hayError) {
          this.errores = true;
          this.mensajeError = resp.mensajeError;
        } else {
          this.router.navigate(['/loguearse', { registrado: 'exitoso' }]);
        }
      },
      (errorResp) => {
        this.errores = true;
        this.mensajeError = errorResp.error.title;
      }
    );
  }
}
