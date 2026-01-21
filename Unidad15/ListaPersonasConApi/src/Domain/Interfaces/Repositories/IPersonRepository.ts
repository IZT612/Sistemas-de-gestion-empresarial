import { Person } from '../../../Data/Entities/Person';

export interface IPersonRepository {
  getAll(): Promise<Person[]>;
  getById(id: number): Promise<Person | null>;

  create(person: Person): Promise<Person>;
  update(person: Person): Promise<Person>;
  delete(id: number): Promise<void>;
}
