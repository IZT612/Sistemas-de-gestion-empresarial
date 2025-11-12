using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.Entities;

namespace Domain.UseCases
{
    public class DefaultGetMisionesUC: IGetMisionesUseCase
    {

        public List<Mision> getMisionesUseCase(IMisionesRepository repository)
        {
            /* var horaActual = DateTime.Now.TimeOfDay;

            if (horaActual < TimeSpan.FromHours(8) || horaActual >= TimeSpan.FromHours(24))
            {

                throw new InvalidOperationException("Debes descansar y volver a intentarlo a las 8 de la mañana");

            } */

            return repository.getMisiones();

        }

    }
    
}
