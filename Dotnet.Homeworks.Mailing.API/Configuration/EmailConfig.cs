namespace Dotnet.Homeworks.Mailing.API.Configuration;

public class EmailConfig
{
    public string Email { get; set; } = null!;
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Password { get; set; } = null!;
}