import { Department } from '../../../Data/Entities/Department';

export interface IDepartmentRepository {
  getAll(): Promise<Department[]>;
  getById(id: number): Promise<Department | null>;

  create(department: Department): Promise<Department>;
  update(department: Department): Promise<Department>;
  delete(id: number): Promise<void>;
}
