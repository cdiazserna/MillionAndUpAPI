using MillionAndUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillionAndUp.Domain.Interfaces
{
    public interface ISecurityUnitOfWork
    {
        Task<string> GetToken(UserPayload user);
    }
}
