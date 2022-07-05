using CleanArchitecture.Application.Models;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Contracts.Infraestructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
