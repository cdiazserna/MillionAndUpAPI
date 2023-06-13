using System.Net;

namespace MillionAndUp.Models
{
    public class PropertyFiltersDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? CodeInternal { get; set; }
        public int? Year { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerAddress { get; set; }
        public string? PropertyTraceName { get; set; }
        public decimal? Value { get; set; }
        public decimal? Tax { get; set; }
    }
}
