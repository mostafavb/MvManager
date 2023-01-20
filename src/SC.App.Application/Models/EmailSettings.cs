using System.Dynamic;

namespace SC.App.Application.Models;
public class EmailSettings
{
    public const string Position = "EmailSettings";
    public string Host { get; set; } 
    public string Email { get; set; } 
    public string Port { get; set; } 
    public string User { get; set; } 
    public string UserPassword { get; set; } 
}
