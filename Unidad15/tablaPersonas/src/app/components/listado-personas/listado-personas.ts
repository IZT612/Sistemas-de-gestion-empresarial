import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

interface Persona {
  nombre: string;
  apellidos: string;
  genero: string;
  edad: number;
}

@Component({
  selector: 'app-listado-personas',
  imports: [RouterLink, CommonModule],
  templateUrl: './listado-personas.html',
  styleUrl: './listado-personas.css',
})
export class ListadoPersonas {

  personas: Persona[] = [
    { nombre: 'Iván', apellidos: 'Zamora Torres', genero: 'Masculino', edad: 0 },
    { nombre: 'Jose Enrique', apellidos: 'Muñoz Galloso', genero: 'Masculino', edad: 0 },
    { nombre: 'Fernando', apellidos: 'Galiana', genero: 'Masculino', edad: 0 }
  ];

}
