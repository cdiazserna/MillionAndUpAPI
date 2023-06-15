using Microsoft.AspNetCore.Http;
using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Domain.UnitsOfWork;
using MillionAndUp.Models;
using Moq;

namespace MillionAndUp.NUnitTests.DomainTests.UnitsOfWorkTests
{
    [TestFixture]
    public class PropertyImageUnitOfWorkTests
    {
        private Mock<IGenericRepository<PropertyImage>> repoMock;
        private IPropertyImageUnitOfWork unitOfWork;
        private Mock<IFormFile> imageStream;
        private FileUploadPayload uploadPayload;
        private PropertyImage propertyImage;

        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IGenericRepository<PropertyImage>>();
            unitOfWork = new PropertyImageUnitOfWork(repoMock.Object);
            imageStream = new Mock<IFormFile>();
            uploadPayload = new FileUploadPayload
            {
                Enabled = true,
                PropertyId = Guid.NewGuid().ToString(),
                Name = "TestImage.jpg",
                ImageDetails = imageStream.Object
            };
            propertyImage = new PropertyImage
            {
                Id = Guid.NewGuid(),
                Name = "TestImage.jpg",
                FileData = new byte[] { 0x01, 0x02, 0x03 }
            };
        }

        [Test]
        public async Task UploadImageAsync_ShouldAddPropertyImageToRepository()
        {
            repoMock.Setup(repo => repo.Add(It.IsAny<PropertyImage>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            await unitOfWork.UploadImageAsync(uploadPayload);

            repoMock.Verify(repo => repo.Add(It.IsAny<PropertyImage>()), Times.Once);
        }

        [Test]
        public async Task DownloadImageByIdAsync_ShouldCopyStreamToFile()
        {
            repoMock.Setup(repo => repo.Get(It.IsAny<Guid>()))
                .ReturnsAsync(propertyImage);

            await unitOfWork.DownloadImageByIdAsync(propertyImage.Id.ToString());

            var expectedFilePath = Path.Combine(Directory.GetCurrentDirectory(), "FileDownloaded", propertyImage.Name);
            Assert.IsTrue(File.Exists(expectedFilePath));
        }
    }
}
