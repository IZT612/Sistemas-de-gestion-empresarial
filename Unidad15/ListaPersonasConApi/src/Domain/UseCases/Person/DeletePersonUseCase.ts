import { IPersonRepository } from '../../Interfaces/Repositories/IPersonRepository';
import { IDeletePersonUseCase } from '../../Interfaces/UseCases/Person/IDeletePersonUseCase';

export class DeletePersonUseCase implements IDeletePersonUseCase {
  constructor(private personRepository: IPersonRepository) {}

  async execute(id: number): Promise<void> {
    const today = new Date().getDay(); // 0 = domingo

    if (today === 0) {
      throw new Error('No está permitido eliminar personas en domingo');
    }

    await this.personRepository.delete(id);
  }
}
