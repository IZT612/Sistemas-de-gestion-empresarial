using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IMisionesRepository
    {

        // Devuelve todas las misiones
        List<Mision> getMisiones();

        // Devuelve una misión por ID
        Mision? getMisionById(int id);

    }
}
