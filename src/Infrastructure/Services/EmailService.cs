using FutManagement.Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace FutManagement.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }

    public Task SendTransferNotificationEmail(Guid transferId)
    {
        _logger.LogInformation("--- SIMULATING SENDING EMAIL ---");
        _logger.LogInformation("Transfer {TransferId} has been completed. Notifying relevant parties.", transferId);
        _logger.LogInformation("--- EMAIL SENT (SIMULATED) ---");

        return Task.CompletedTask;
    }
}