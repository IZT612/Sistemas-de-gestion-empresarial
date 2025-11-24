using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Entities;

namespace Domain.Interfaces
{
    using Domain.DTO;

    public interface IGetPersonasWithDepartamentoUC
    {
        PersonaWithNombreDepartamentoDTO[] getPersonasWithNombreDepartamento();
    }
}
