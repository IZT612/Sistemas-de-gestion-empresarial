import { IPersonRepository } from '../../Interfaces/Repositories/IPersonRepository';
import { Person } from '../../../Data/Entities/Person';
import { ICreatePersonUseCase } from '../../Interfaces/UseCases/Person/ICreatePersonUseCase';

export class CreatePersonUseCase implements ICreatePersonUseCase {
  constructor(private personRepository: IPersonRepository) {}

  async execute(person: Person): Promise<Person> {
    return this.personRepository.create(person);
  }
}
