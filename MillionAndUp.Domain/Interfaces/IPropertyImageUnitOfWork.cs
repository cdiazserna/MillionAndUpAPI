using MillionAndUp.Models;

namespace MillionAndUp.Domain.Interfaces
{
    public interface IPropertyImageUnitOfWork
    {
        Task UploadImageAsync(FileUploadPayload payload);
        Task DownloadImageByIdAsync(string Id);
    }
}
