using NEXOSAPI.Domain.Settings;
using System.Threading.Tasks;

namespace NEXOSAPI.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
