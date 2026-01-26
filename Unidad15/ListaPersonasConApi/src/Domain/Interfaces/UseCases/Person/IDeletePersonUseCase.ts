export interface IDeletePersonUseCase {
  execute(id: number): Promise<void>;
}
