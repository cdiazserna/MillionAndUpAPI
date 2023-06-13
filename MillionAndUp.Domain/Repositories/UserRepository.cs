using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MillionAndUp.Data;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Helpers.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.Domain.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IDBHelper dBHelper, IConfiguration configuration) : base(context, dBHelper, configuration)
        {
        }

        public async Task<List<User>> GetUserByLoginAndPassword(string login, string password)
        {
            return await _context.Users.Where(x => x.Password.Equals(password)
                              && x.Login.Equals(login)).ToListAsync();
        }
    }
}
