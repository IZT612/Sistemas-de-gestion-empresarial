import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { MatSliderModule } from '@angular/material/slider';

@Component({
  selector: 'app-formulario-persona',
  imports: [CommonModule, FormsModule, MatRadioModule, MatSliderModule],
  templateUrl: './formulario-persona.html',
  styleUrl: './formulario-persona.css',
})
export class FormularioPersona {

  nombre: string = '';
  apellidos: string = '';
  genero: string = 'Masculino';
  edad: number = 0;

  onSubmit() {
    if (this.nombre && this.apellidos) {
      alert(`Persona agregada: ${this.nombre} ${this.apellidos} - ${this.genero} - Edad: ${this.edad}`);
      this.nombre = '';
      this.apellidos = '';
      this.genero = 'Masculino';
      this.edad = 0;
    } else {
      alert('Por favor completa todos los campos');
    }
  }

}
