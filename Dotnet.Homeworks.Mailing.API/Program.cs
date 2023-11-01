using Dotnet.Homeworks.Mailing.API.Configuration;
using Dotnet.Homeworks.Mailing.API.Services;
using Dotnet.Homeworks.Mailing.API.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMasstransitRabbitMq(builder.Configuration);
builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));

builder.Services.AddScoped<IMailingService, FakeMailingService>();

var app = builder.Build();

app.Run();