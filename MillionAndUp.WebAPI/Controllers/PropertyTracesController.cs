using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PropertyTracesController : GenericController<PropertyTrace>
    {
        public PropertyTracesController(IGenericUnitOfWork<PropertyTrace> unit) : base(unit)
        {
        }
    }
}
