// src/data/repositories/PersonRepository.ts

import { IPersonRepository } from '../../Domain/Interfaces/Repositories/IPersonRepository';
import { Person } from '../Entities/Person';
import { ApiDataSource } from '../DataSources/api/ApiDataSource';

export class PersonRepository implements IPersonRepository {
  constructor(private apiDataSource: ApiDataSource) {}

  async getAll(): Promise<Person[]> {
    return this.apiDataSource.get<Person[]>('/personas');
  }

  async getById(id: number): Promise<Person | null> {
    try {
      return await this.apiDataSource.get<Person>(`/personas/${id}`);
    } catch {
      return null;
    }
  }

  async create(person: Person): Promise<Person> {
    return this.apiDataSource.post<Person>('/personas', person);
  }

  async update(person: Person): Promise<Person> {
    return this.apiDataSource.put<Person>(`/personas/${person.id}`, person);
  }

  async delete(id: number): Promise<void> {
    await this.apiDataSource.delete(`/personas/${id}`);
  }
}
