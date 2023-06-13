using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PropertyImagesController : GenericController<PropertyImage>
    {
        public PropertyImagesController(IGenericUnitOfWork<PropertyImage> unit) : base(unit)
        {
        }
    }
}
