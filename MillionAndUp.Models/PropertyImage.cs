using Microsoft.AspNetCore.Http;

namespace MillionAndUp.Models
{
    public class PropertyImage : AuditBase
    {
        public byte[] FileData { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public Property? Property { get; set; }
        public Guid PropertyId { get; set; }
    }
}
