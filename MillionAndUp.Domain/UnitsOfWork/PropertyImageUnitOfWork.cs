using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Models;

namespace MillionAndUp.Domain.UnitsOfWork
{
    public class PropertyImageUnitOfWork : IPropertyImageUnitOfWork
    {
        readonly IGenericRepository<PropertyImage> _repo;
        public PropertyImageUnitOfWork(IGenericRepository<PropertyImage> repo)
        {
            _repo = repo;
        }
        public async Task UploadImageAsync(FileUploadPayload payload)
        {

            var imageDetails = new PropertyImage()
            {
                Enabled = payload.Enabled,
                Id = Guid.NewGuid(),
                PropertyId = new Guid(payload.PropertyId),
                Name = payload.Name,
            };

            using (var stream = new MemoryStream())
            {
                payload.ImageDetails.CopyTo(stream);
                imageDetails.FileData = stream.ToArray();
            }
            await _repo.Add(imageDetails);
        }

        public async Task DownloadImageByIdAsync(string Id)
        {

            var file = _repo.Get(new Guid(Id));

            var content = new System.IO.MemoryStream(file.Result.FileData);
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "FileDownloaded");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var path = Path.Combine(
               Directory.GetCurrentDirectory(), "FileDownloaded",
               file.Result.Name);

            await CopyStream(content, path);

        }
        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
