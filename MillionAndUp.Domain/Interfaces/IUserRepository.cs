using MillionAndUp.Models;

namespace MillionAndUp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserByLoginAndPassword(string login, string password);
    }
}
