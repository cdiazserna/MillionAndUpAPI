using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OwnersController : GenericController<Owner>
    {
        public OwnersController(IGenericUnitOfWork<Owner> unit) : base(unit)
        {
        }
    }
}
