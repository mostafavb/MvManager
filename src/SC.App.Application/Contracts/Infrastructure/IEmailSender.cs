using SC.App.Application.Models;

namespace SC.App.Application.Contracts.Infrastructure;
public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}
