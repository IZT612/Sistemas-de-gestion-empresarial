import { Person } from '../../../../Data/Entities/Person';

export interface IGetPersonsUseCase {
  execute(): Promise<Person[]>;
}
