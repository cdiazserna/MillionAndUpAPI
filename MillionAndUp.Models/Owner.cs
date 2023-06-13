namespace MillionAndUp.Models
{
    public class Owner : AuditBase
    {
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public IEnumerable<Property>? Properties { get; set; }
    }
}
