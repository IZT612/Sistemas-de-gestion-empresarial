import { Person } from '../../../../Data/Entities/Person';

export interface ICreatePersonUseCase {
  execute(person: Person): Promise<Person>;
}
