using System.ComponentModel.DataAnnotations;

namespace MillionAndUp.Models
{
    public class Owner : AuditBase
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public IEnumerable<Property>? Properties { get; set; }
    }
}
