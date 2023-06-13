using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PropertiesController : GenericController<Property>
    {
        private readonly IPropertiesUnitOfWork _unitOfWork;
        public PropertiesController(IGenericUnitOfWork<Property> unit, IPropertiesUnitOfWork unitOfWork) : base(unit)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("getPropertiesByFilter")]
        public async Task<List<PropertyFiltersDTO>> GetPropertiesByFilter([FromQuery] PropertyFiltersPayload payload)
        {
            return await _unitOfWork.GetPropertiesByFilter(payload);
        }
    }
}
