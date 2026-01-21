import { IPersonRepository } from '../../Interfaces/Repositories/IPersonRepository';
import { Person } from '../../../Data/Entities/Person';
import { IGetPersonByIdUseCase } from '../../Interfaces/UseCases/Person/IGetPersonByIdUseCase';

export class GetPersonByIdUseCase implements IGetPersonByIdUseCase {
  constructor(private personRepository: IPersonRepository) {}

  async execute(id: number): Promise<Person | null> {
    return this.personRepository.getById(id);
  }
}
