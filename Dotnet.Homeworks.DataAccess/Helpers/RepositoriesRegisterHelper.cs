using Dotnet.Homeworks.DataAccess.Repositories;
using Dotnet.Homeworks.Domain.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Homeworks.DataAccess.Helpers;

public static class RepositoriesRegisterHelper
{
    public static void RegisterRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
    }
}