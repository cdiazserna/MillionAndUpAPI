using MillionAndUp.Models;

namespace MillionAndUp.Domain.Interfaces
{
    public interface IPropertiesUnitOfWork
    {
        Task<List<PropertyFiltersDTO>> GetPropertiesByFilter(PropertyFiltersPayload payload);
    }
}
