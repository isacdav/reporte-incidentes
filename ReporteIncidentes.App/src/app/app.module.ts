import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './common/header/header.component';
import { Routes, RouterModule } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { IncidenciasComponent } from './incidencias/incidencias.component';
import { NuevaComponent } from './incidencias/nueva/nueva.component';
import { CuentaComponent } from './cuenta/cuenta.component';
import { RegistrarComponent } from './cuenta/registrar/registrar.component';
import { CuentaModule } from './cuenta/cuenta.module';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: InicioComponent },
  { path: 'incidencias', component: IncidenciasComponent },
  { path: 'nueva', component: NuevaComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    InicioComponent,
    IncidenciasComponent,
    NuevaComponent
  ],
  imports: [RouterModule.forRoot(routes), BrowserModule, CuentaModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
