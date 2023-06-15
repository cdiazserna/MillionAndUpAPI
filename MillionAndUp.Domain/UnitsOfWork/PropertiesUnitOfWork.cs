using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.Domain.UnitsOfWork
{
    public class PropertiesUnitOfWork : IPropertiesUnitOfWork
    {
        readonly IGenericRepository<Property> _repo;
        public PropertiesUnitOfWork(IGenericRepository<Property> repo)
        {
            _repo = repo;
        }
        public async Task<List<PropertyFiltersDTO>> GetPropertiesByFilter(PropertyFiltersPayload payload)
        {
            var parameters = new List<ExecuteParameter>();

            parameters.Add(new ExecuteParameter() { Name = "Address", Value = payload.Address });
            parameters.Add(new ExecuteParameter() { Name = "MinPrice", Value = payload.MinPrice });
            parameters.Add(new ExecuteParameter() { Name = "MaxPrice", Value = payload.MaxPrice });
            parameters.Add(new ExecuteParameter() { Name = "CodeInternal", Value = payload.CodeInternal });

            return await _repo.ExecuteStoreProcedure<PropertyFiltersDTO>("getPropertiesByFilter", parameters);
        }
    }
}
