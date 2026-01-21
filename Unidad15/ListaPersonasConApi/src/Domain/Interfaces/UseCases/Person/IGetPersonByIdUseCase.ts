import { Person } from '../../../../Data/Entities/Person';

export interface IGetPersonByIdUseCase {
  execute(id: number): Promise<Person | null>;
}
