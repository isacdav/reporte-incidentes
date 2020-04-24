import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './common/header/header.component';
import { Routes, RouterModule } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { IncidenciasComponent } from './incidencias/incidencias.component';
import { NuevaComponent } from './incidencias/nueva/nueva.component';
import { ListadoComponent } from './incidencias/listado/listado.component';
import { CuentaModule } from './cuenta/cuenta.module';
import { API_KEY } from './common/secret/API_KEY';

import { AgmCoreModule } from '@agm/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { IncidenciaComponent } from './incidencias/incidencia/incidencia.component';
import { IncidenciaGuard } from './services/incidencia.guard';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: InicioComponent },
  { path: 'incidencias', component: ListadoComponent },
  { path: 'nueva', component: NuevaComponent },
  {
    path: 'misreportes',
    component: ListadoComponent,
    canActivate: [IncidenciaGuard],
  },
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    InicioComponent,
    IncidenciasComponent,
    NuevaComponent,
    ListadoComponent,
    IncidenciaComponent,
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    HttpClientModule,
    CuentaModule,
    AgmCoreModule.forRoot({
      apiKey: API_KEY.google_maps(),
    }),
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [IncidenciaGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}
