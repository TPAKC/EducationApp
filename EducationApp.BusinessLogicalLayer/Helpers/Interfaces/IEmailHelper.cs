using System.Threading.Tasks;

namespace EducationApp.BusinessLogicalLayer.Helpers.Interfaces
{
    public interface IEmailHelper
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
