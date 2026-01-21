import { Department } from './Department';

export interface Person {
  id: number;
  nombre: string;
  apellidos: string;
  direccion: string;
  telefono: string;
  foto: string;        // URL de la foto
  fechaNac: string;    // ISO string (ej: "1995-06-20")
  departamento: Department;
}
