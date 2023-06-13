using Microsoft.AspNetCore.Mvc;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PropertyImagesController : GenericController<PropertyImage>
    {
        private readonly IPropertyImageUnitOfWork _unitPropertyImage;
        public PropertyImagesController(IGenericUnitOfWork<PropertyImage> unit, IPropertyImageUnitOfWork unitPropertyImage) : base(unit)
        {
            _unitPropertyImage = unitPropertyImage;
        }

        [HttpPost("uploadSingleImage")]
        public async Task<ActionResult> UploadImage([FromForm] FileUploadPayload imageDetails)
        {
            if (imageDetails == null)
            {
                return BadRequest();
            }

                await _unitPropertyImage.UploadImageAsync(imageDetails);
                return Ok();
          
        }
        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(string id)
        {
            if (id.Equals(String.Empty))
            {
                return BadRequest();
            }

            try
            {
                await _unitPropertyImage.DownloadImageByIdAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
