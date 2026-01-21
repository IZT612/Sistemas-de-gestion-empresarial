import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RouterOutlet } from '@angular/router';
import { MatRadioModule } from '@angular/material/radio';
import { MatSliderModule } from '@angular/material/slider';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

interface Persona {
  nombre: string;
  apellidos: string;
  genero: string;
  edad: number;
}

@Component({
  selector: 'app-tabla-personas',
  standalone: true,
  imports: [RouterOutlet, MatProgressSpinnerModule, MatRadioModule, MatSliderModule, FormsModule, CommonModule],
  templateUrl: './tabla-personas.html',
  styleUrls: ['./tabla-personas.css'],
})
export class TablaPersonas {

  personas: Persona[] = [
    { nombre: 'Iván', apellidos: 'Zamora Torres', genero: 'Masculino', edad: 0 },
    { nombre: 'Jose Enrique', apellidos: 'Muñoz Galloso', genero: 'Masculino', edad: 0 },
    { nombre: 'Fernando', apellidos: 'Galiana', genero: 'Masculino', edad: 0 }
  ];

  constructor(private router: Router) {}

  abrirFormulario() {
    this.router.navigate(['formulario']);
  }

  abrirListado() {
    window.open('/listado', '_blank');
  }

  abrirFormularioReactivo() {
    this.router.navigate(['formulario-reactivo']);
  }

}


