using BaltaStore.Domain.Repositories;
using BaltaStore.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BaltaStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IProductRepository, ProductRepository>();

        return services;
    }
}