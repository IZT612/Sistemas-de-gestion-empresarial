import { Person } from '../../../../Data/Entities/Person';

export interface IUpdatePersonUseCase {
  execute(person: Person): Promise<Person>;
}
