using FluentEmail.Core;
using Microsoft.Extensions.Options;
using SC.App.Application.Contracts.Infrastructure;
using SC.App.Application.Models;



namespace CS.App.Infrastructure.Mail;
public class EmailSender : IEmailSender
{
    private readonly IFluentEmail _email;

    private EmailSettings _emailSettings { get; }
    public EmailSender(IOptions<EmailSettings> emailSettings,IFluentEmail email)
    {
        _emailSettings = emailSettings.Value;
        this._email = email;
    }

    public async Task<bool> SendEmail(SC.App.Application.Models.Email email)
    {
        var emailTo = _email
            .To(email.To)
            .Subject(email.Subject)
            .Body(email.Body);
        var result = await emailTo.SendAsync();
        return result.Successful;
    }
}
