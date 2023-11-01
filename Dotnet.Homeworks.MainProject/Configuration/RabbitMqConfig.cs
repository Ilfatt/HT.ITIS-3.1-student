namespace Dotnet.Homeworks.MainProject.Configuration;

public class RabbitMqConfig
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Hostname { get; set; } = null!;
    public int Port { get; set; }
}