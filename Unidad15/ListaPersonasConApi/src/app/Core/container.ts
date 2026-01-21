// src/app/di/Container.ts

import { ApiDataSource } from "../../Data/DataSources/api/ApiDataSource";

// Repositories
import { PersonRepository } from "../../Data/Repositories/PersonRepository";
import { DepartmentRepository } from "../../Data/Repositories/DepartmentRepository";

// ========== PERSON USECASES ==========
import { GetPersonsUseCase } from "../../Domain/UseCases/Person/GetPersonsUseCase";
import { GetPersonByIdUseCase } from "../../Domain/UseCases/Person/GetPersonByIdUseCase";
import { CreatePersonUseCase } from "../../Domain/UseCases/Person/CreatePersonUseCase";
import { UpdatePersonUseCase } from "../../Domain/UseCases/Person/UpdatePersonUseCase";
import { DeletePersonUseCase } from "../../Domain/UseCases/Person/DeletePersonUseCase";

// ========== DEPARTMENT USECASES ==========
//import { GetDepartmentsUseCase } from "../../Domain/UseCases/Department/GetDepartmentsUseCase";
//import { GetDepartmentByIdUseCase } from "../../Domain/UseCases/Department/GetDepartmentByIdUseCase";
//import { CreateDepartmentUseCase } from "../../Domain/UseCases/Department/CreateDepartmentUseCase";
//import { UpdateDepartmentUseCase } from "../../Domain/UseCases/Department/UpdateDepartmentUseCase";
//import { DeleteDepartmentUseCase } from "../../Domain/UseCases/Department/DeleteDepartmentUseCase";

// ViewModels
//import { DepartmentViewModel } from "../../presentation/viewmodels/departments/DepartmentViewModel";

// =======================================================
// SINGLETONS
// =======================================================

// DataSource (1 sola instancia)
const apiDataSource = new ApiDataSource();

// Repositories (1 sola instancia)
const personRepository = new PersonRepository(apiDataSource);
const departmentRepository = new DepartmentRepository(apiDataSource);

// ========== PERSON USECASES ==========
export const getPersonsUseCase = new GetPersonsUseCase(personRepository);
const getPersonByIdUseCase = new GetPersonByIdUseCase(personRepository);
const createPersonUseCase = new CreatePersonUseCase(personRepository);
const updatePersonUseCase = new UpdatePersonUseCase(personRepository);
const deletePersonUseCase = new DeletePersonUseCase(personRepository);

// ========== DEPARTMENT USECASES ==========
//const getDepartmentsUseCase = new GetDepartmentsUseCase(departmentRepository);
//const getDepartmentByIdUseCase = new GetDepartmentByIdUseCase(departmentRepository);
//const createDepartmentUseCase = new CreateDepartmentUseCase(departmentRepository);
//const updateDepartmentUseCase = new UpdateDepartmentUseCase(departmentRepository);
//const deleteDepartmentUseCase = new DeleteDepartmentUseCase(departmentRepository);


//export const departmentViewModel = new DepartmentViewModel(
 // getDepartmentsUseCase,
 // getDepartmentByIdUseCase,
 // createDepartmentUseCase,
 // updateDepartmentUseCase,
//  deleteDepartmentUseCase
//);
