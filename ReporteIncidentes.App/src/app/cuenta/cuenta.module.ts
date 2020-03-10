import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrarComponent } from './registrar/registrar.component';
import { LogueoComponent } from './logueo/logueo.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'registrarse', component: RegistrarComponent },
  { path: 'loguearse', component: LogueoComponent }
];

@NgModule({
  declarations: [LogueoComponent, RegistrarComponent],
  imports: [CommonModule, RouterModule.forChild(routes)]
})
export class CuentaModule {}
