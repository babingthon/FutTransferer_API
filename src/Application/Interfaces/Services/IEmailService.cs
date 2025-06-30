namespace FutManagement.Application.Interfaces.Services;

public interface IEmailService
{
    Task SendTransferNotificationEmail(Guid transferId);
}