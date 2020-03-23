import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { RegistrarComponent } from './registrar/registrar.component';
import { LogueoComponent } from './logueo/logueo.component';

const routes: Routes = [
  { path: 'registrarse', component: RegistrarComponent },
  { path: 'loguearse', component: LogueoComponent }
];

@NgModule({
  declarations: [LogueoComponent, RegistrarComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CuentaModule {}
