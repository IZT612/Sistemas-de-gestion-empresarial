import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms'; // <- IMPORTAR
import { FormularioReactivo } from './formulario-reactivo';

describe('FormularioReactivoComponent', () => {
  let component: FormularioReactivo;
  let fixture: ComponentFixture<FormularioReactivo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FormularioReactivo], // <- tu componente
      imports: [ReactiveFormsModule]               // <- necesario para forms
    })
    .compileComponents();

    fixture = TestBed.createComponent(FormularioReactivo);
    component = fixture.componentInstance;
    fixture.detectChanges(); // <- importante para inicializar el componente
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
