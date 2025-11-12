using Domain.Entities;
using Domain.Repositories;


namespace Domain.Interfaces
{
    public interface IGetMisionesUseCase
    {

        public List<Mision> getMisionesUseCase(IMisionesRepository repository);

    }
}
