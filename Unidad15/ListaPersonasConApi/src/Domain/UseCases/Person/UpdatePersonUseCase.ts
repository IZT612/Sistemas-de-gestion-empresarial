import { IPersonRepository } from '../../Interfaces/Repositories/IPersonRepository';
import { Person } from '../../../Data/Entities/Person';
import { IUpdatePersonUseCase } from '../../Interfaces/UseCases/Person/IUpdatePersonUseCase';

export class UpdatePersonUseCase implements IUpdatePersonUseCase {
  constructor(private personRepository: IPersonRepository) {}

  async execute(person: Person): Promise<Person> {
    return this.personRepository.update(person);
  }
}
