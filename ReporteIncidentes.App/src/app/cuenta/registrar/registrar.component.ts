import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css'],
})
export class RegistrarComponent implements OnInit {
  errores: boolean = false;
  mensajeError: string;

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

  constructor(private fb: FormBuilder, private usuarioSrv: UsuarioService) {}

  ngOnInit() {}

  guardar() {
    this.errores = false;

    this.registroForm.controls['idUsuario'].setValue(0);
    this.registroForm.controls['estadoUsuario'].setValue(0);
    this.registroForm.controls['codigoActivacion'].setValue(0);

    if (!this.registroForm.valid) {
      this.mensajeError = 'Favor revisar el formulario. No es valido.';
      return;
    }

    this.usuarioSrv.register(this.registroForm.value).subscribe(
      (resp) => {
        debugger;
        if (resp.hayError) {
          this.errores = true;
          this.mensajeError = resp.mensajeError;
        } else {
          //irse a otra pagina
        }
      },
      (errorResponse) => {
        this.errores = true;
        this.mensajeError = errorResponse.error.title;
      }
    );
  }
}
