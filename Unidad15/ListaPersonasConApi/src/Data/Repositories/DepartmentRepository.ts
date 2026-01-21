// src/data/repositories/DepartmentRepository.ts

import { IDepartmentRepository } from '../../Domain/Interfaces/Repositories/IDepartmentRepository';
import { Department } from '../Entities/Department';
import { ApiDataSource } from '../DataSources/api/ApiDataSource';

export class DepartmentRepository implements IDepartmentRepository {
  constructor(private apiDataSource: ApiDataSource) {}

  async getAll(): Promise<Department[]> {
    return this.apiDataSource.get<Department[]>('/departamentos');
  }

  async getById(id: number): Promise<Department | null> {
    try {
      return await this.apiDataSource.get<Department>(`/departamentos/${id}`);
    } catch {
      return null;
    }
  }

  async create(department: Department): Promise<Department> {
    return this.apiDataSource.post<Department>('/departamentos', department);
  }

  async update(department: Department): Promise<Department> {
    return this.apiDataSource.put<Department>(
      `/departamentos/${department.id}`,
      department
    );
  }

  async delete(id: number): Promise<void> {
    await this.apiDataSource.delete(`/departamentos/${id}`);
  }
}
