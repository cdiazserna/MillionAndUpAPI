using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ISecurityUnitOfWork _unit;
        public SecurityController(ISecurityUnitOfWork unit)
        {
            _unit = unit;
        }
        [HttpPost]
        [Route("getToken")]
        public async Task<string> GetToken(UserPayload user)
        {
            var token = await _unit.GetToken(user);
            return token;
        }
    }
}
