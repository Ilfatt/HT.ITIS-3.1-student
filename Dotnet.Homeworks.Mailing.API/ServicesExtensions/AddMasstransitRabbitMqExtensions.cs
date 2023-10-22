using Dotnet.Homeworks.Mailing.API.Configuration;
using Dotnet.Homeworks.Mailing.API.Consumers;
using MassTransit;

namespace Dotnet.Homeworks.Mailing.API.ServicesExtensions;

public static class AddMasstransitRabbitMqExtensions
{
    public static IServiceCollection AddMasstransitRabbitMq(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var rabbitConfiguration = configuration.GetSection("RabbitMqConfig").Get<RabbitMqConfig>()!;
        
        return services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<EmailConsumer>();
            busConfigurator.UsingRabbitMq((ctx, busFactoryConf) =>
            {
                busFactoryConf.ConfigureEndpoints(ctx);
                busFactoryConf.Host($"amqp://{rabbitConfiguration.Username}:{rabbitConfiguration.Password}" +
                                        $"@{rabbitConfiguration.Hostname}:{rabbitConfiguration.Port}");
            });
        });
    }
}