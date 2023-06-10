using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MillionAndUp.Models
{
    public class Property : AuditBase
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public string? CodeInternal { get; set; }
        public int? Year { get; set; }
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
        public IEnumerable<PropertyTrace>? PropertyTraces { get; set; }
        public IEnumerable<PropertyImage>? PropertyImages { get; set; }
    }
}
