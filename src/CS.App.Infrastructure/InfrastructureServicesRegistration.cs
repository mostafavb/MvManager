using CS.App.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Application.Contracts.Infrastructure;
using SC.App.Application.Models;
using System.Net;

namespace CS.App.Infrastructure;
public static class InfrastructureServicesRegistration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(EmailSettings.Position));
        services.AddTransient<IEmailSender, EmailSender>();

        services.AddFluentEmail(configuration.GetValue<string>("EmailSettings:Email"))
        .AddSmtpSender(new System.Net.Mail.SmtpClient()
        {

            Port = configuration.GetValue<int>("EmailSettings:Port"),
            Host = configuration.GetValue<string>("EmailSettings:Host") ?? "smtp.gmail.com",
            EnableSsl = true,
            DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(configuration.GetValue<string>("EmailSettings:User"),
                                                configuration.GetValue<string>("EmailSettings:Password")),
        });

        return services;
    }
}
