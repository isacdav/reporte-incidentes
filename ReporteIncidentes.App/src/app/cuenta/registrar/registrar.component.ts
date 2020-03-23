import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.css']
})
export class RegistrarComponent implements OnInit {

  registroForm = this.fb.group({
    cedula: ['', Validators.required],
    nombre: [''],
  });

  constructor(private fb: FormBuilder) {
  }

  ngOnInit() {
  }

  guardar(){
  }

}
