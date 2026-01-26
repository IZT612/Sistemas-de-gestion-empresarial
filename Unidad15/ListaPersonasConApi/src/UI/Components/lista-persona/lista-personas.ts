import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Person } from '../../../Data/Entities/Person';
import { getPersonsUseCase } from '../../../app/Core/container';

@Component({
  selector: 'app-lista-personas',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './lista-personas.html',
  styleUrl: './lista-personas.css'
})
export class ListaPersonasComponent implements OnInit {
  persons = signal<Person[]>([]);

  async ngOnInit() {
    try {
      const data = await getPersonsUseCase.execute();
      this.persons.set(data);
    } catch (error) {
      console.error('Error fetching persons:', error);
    }
  }
}
