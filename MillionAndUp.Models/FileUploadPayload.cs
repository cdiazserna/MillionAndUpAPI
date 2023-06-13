using Microsoft.AspNetCore.Http;

namespace MillionAndUp.Models
{
    public class FileUploadPayload
    {
        public IFormFile ImageDetails { get; set; }
        public string PropertyId { get; set; }
        public bool Enabled { get; set; }   
        public string Name { get; set; }

    }
}
