import { Routes } from '@angular/router';
import { FormularioPersona } from './components/formulario-persona/formulario-persona';
import { ListadoPersonas } from './components/listado-personas/listado-personas';
import { TablaPersonas } from './components/tabla-personas/tabla-personas';
import { FormularioReactivo } from './components/formulario-reactivo/formulario-reactivo';

export const routes: Routes = [
  {
    path: '',
    component: TablaPersonas,
    children: [
      { path: 'formulario', component: FormularioPersona }
    ]
  },
  { path: 'listado', component: ListadoPersonas },
  { path: 'formulario-reactivo', component: FormularioReactivo }
];

