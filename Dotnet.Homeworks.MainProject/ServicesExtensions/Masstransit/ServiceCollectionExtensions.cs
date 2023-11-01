using Dotnet.Homeworks.MainProject.Configuration;
using MassTransit;

namespace Dotnet.Homeworks.MainProject.ServicesExtensions.Masstransit;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMasstransitRabbitMq(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var rabbitConfiguration = configuration.GetSection("RabbitMqConfig").Get<RabbitMqConfig>()!;
        
        return services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((ctx, busFactoryConf) =>
            {
                busFactoryConf.ConfigureEndpoints(ctx);
                busFactoryConf.Host($"amqp://{rabbitConfiguration.Username}:{rabbitConfiguration.Password}" +
                                    $"@{rabbitConfiguration.Hostname}:{rabbitConfiguration.Port}");
            });
        });
    }
}