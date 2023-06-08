﻿using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PropertiesController : GenericController<Property>
    {
        public PropertiesController(IGenericUnitOfWork<Property> unit) : base(unit)
        {
        }
    }
}
