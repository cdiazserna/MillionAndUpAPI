using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PropertyTracesController : GenericController<PropertyTrace>
    {
        public PropertyTracesController(IGenericUnitOfWork<PropertyTrace> unit) : base(unit)
        {
        }
    }
}
