import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatRadioModule } from '@angular/material/radio';
import { MatSliderModule } from '@angular/material/slider';
import { Router } from '@angular/router';

@Component({
  selector: 'app-formulario-reactivo',
  templateUrl: './formulario-reactivo.html',
  imports: [ReactiveFormsModule, CommonModule, MatRadioModule, MatSliderModule],
  styleUrls: ['./formulario-reactivo.css']
})
export class FormularioReactivo implements OnInit {

  formulario!: FormGroup;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      apellidos: new FormControl('', [Validators.required]),
      genero: new FormControl('Masculino', [Validators.required]),
      edad: new FormControl(0, [Validators.required])
    });
  }

saluda() {
  if (this.formulario.valid) {
    const nombre = this.formulario.controls['nombre'].value;
    const apellidos = this.formulario.controls['apellidos'].value;
    const genero = this.formulario.controls['genero'].value;
    const edad = this.formulario.controls['edad'].value;

    alert(`Hola ${nombre} ${apellidos} - ${genero} - Edad: ${edad}`);
  } else {
    alert('Por favor completa todos los campos');
  }
}

goBack() {
  this.router.navigate(['/']);
}

}
