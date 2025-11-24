using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.DTO;
using Domain.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    internal class GetPersonasWithDepartamentoUC: IGetPersonasWithDepartamentoUC
    {

        private readonly IPeopleRepository _repository;

        public GetPersonasWithDepartamentoUC(IPeopleRepository repository)
        {
            _repository = repository;
        }
        public PersonaWithNombreDepartamentoDTO[] getPersonasWithNombreDepartamento()
        {
            List<PersonaWithNombreDepartamentoDTO> listaPersonasConNombreDepartamento = [];
            List<Departamento> listaDepartamentos = _repository.getListaDepartamentos().ToList();
            foreach (Persona persona in _repository.getListaPersonas())
            {
                listaPersonasConNombreDepartamento.Add(PersonaToPersonaWithNombreDepartamentoDTO.Mappers(persona, listaDepartamentos));
            }
            return listaPersonasConNombreDepartamento.ToArray();
        }

    }
}
