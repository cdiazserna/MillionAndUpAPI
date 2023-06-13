using MillionAndUp.Models;

namespace MillionAndUp.Domain.Interfaces
{
    public interface ISecurityUnitOfWork
    {
        Task<string> GetToken(UserPayload user);
    }
}
