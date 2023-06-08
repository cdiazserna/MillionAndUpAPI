using System.ComponentModel.DataAnnotations;

namespace MillionAndUp.Models
{
    public class Property : AuditBase
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public string? CodeInternal { get; set; }
        public int? Year { get; set; }
        public Guid OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
