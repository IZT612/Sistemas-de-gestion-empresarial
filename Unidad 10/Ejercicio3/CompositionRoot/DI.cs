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
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            // Registrar las dependencias necesarias para repositorios
            services.AddScoped<IPeopleRepository, PeopleRepositoryAzure>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepositoryAzure>();

            // Registrar las dependencias necesarias para casos de uso
            services.AddScoped<IDepartamentoUC, DefaultDepartamentoUC>();
            services.AddScoped<IPersonaUC, DefaultPersonaUC>();

            return services;
        }
    }
}
