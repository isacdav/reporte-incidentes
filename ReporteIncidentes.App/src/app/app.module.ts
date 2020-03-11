import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './common/header/header.component';
import { Routes, RouterModule } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { IncidenciasComponent } from './incidencias/incidencias.component';
import { NuevaComponent } from './incidencias/nueva/nueva.component';
import { CuentaModule } from './cuenta/cuenta.module';
import { API_KEY } from './common/secret/API_KEY';

import { AgmCoreModule } from '@agm/core';

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
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    CuentaModule,
    AgmCoreModule.forRoot({
      apiKey: API_KEY.google_maps()
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
