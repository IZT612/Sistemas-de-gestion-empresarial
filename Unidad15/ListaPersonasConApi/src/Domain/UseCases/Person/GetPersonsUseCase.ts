import { IPersonRepository } from '../../Interfaces/Repositories/IPersonRepository';
import { Person } from '../../../Data/Entities/Person';
import { IGetPersonsUseCase } from '../../Interfaces/UseCases/Person/IGetPersonsUseCase';

export class GetPersonsUseCase implements IGetPersonsUseCase {
  constructor(private personRepository: IPersonRepository) {}

  async execute(): Promise<Person[]> {
    const persons = await this.personRepository.getAll();
    const today = new Date().getDay(); // 0 = domingo, 5 = viernes, 6 = sábado

    if (today === 5 || today === 6) {
      return persons.filter(p => this.getAge(p.fechaNac) > 18);
    }

    return persons;
  }

  private getAge(fechaNac: string): number {
    const birthDate = new Date(fechaNac);
    const today = new Date();

    let age = today.getFullYear() - birthDate.getFullYear();
    const m = today.getMonth() - birthDate.getMonth();

    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }

    return age;
  }
}
