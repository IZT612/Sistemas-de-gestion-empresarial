using Data.Repositories;
using Domain.Interfaces;
using Domain.Repositories;
using Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class DI
    {
        // Método de extensión para IServiceCollection
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrar las dependencias necesarias
            services.AddScoped<IPeopleRepository, PeopleRepositoryAzure>();
            services.AddScoped<IGetPersonasWithDepartamentoUC, GetPersonasWithDepartamentoUC>();

            return services;
        }
    }
}
