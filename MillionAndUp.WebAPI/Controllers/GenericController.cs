using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;

namespace MillionAndUp.WebAPI.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unit;
        public GenericController(IGenericUnitOfWork<T> unit)
        {
            _unit = unit;
        }
        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await _unit.GetAll();
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<T> GetById(Guid id)
        {
            return await _unit.Get(id);
        }
        [HttpPost]
        public Task Add(T model)
        {
            return _unit.Add(model);
        }
        [HttpPut]
        public void Update(T model)
        {
            _unit.Update(model);
        }
        [HttpDelete]
        public Task Delete(Guid id)
        {
            return _unit.Delete(id);
        }
    }
}
