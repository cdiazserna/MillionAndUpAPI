using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Domain.UnitsOfWork;
using MillionAndUp.Models;
using Moq;

namespace MillionAndUp.NUnitTests.DomainTests.UnitsOfWorkTests
{
    [TestFixture]
    public class GenericUnitOfWorkTests
    {
        private Mock<IGenericRepository<string>> repoMock;
        private GenericUnitOfWork<string> unitOfWork;
        private Random random;
        private Property property;

        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IGenericRepository<string>>();
            unitOfWork = new GenericUnitOfWork<string>(repoMock.Object);
            random = new Random();
            property = new Property
            {
                Id = Guid.NewGuid(),
                Name = "Test Name",
                Address = "Test Address",
                Price = random.Next(0, 100000),
                CodeInternal = "Test Code Internal",
                Year = random.Next(1900, 2024)
            };
        }

        [Test]
        public async Task Add_ShouldCallRepositoryAdd()
        {
            await unitOfWork.Add(property.ToString());

            repoMock.Verify(repo => repo.Add(property.ToString()), Times.Once);
        }

        [Test]
        public void Add_ShouldFail_WhenRepositoryAdd_ThrowsException()
        {
            repoMock.Setup(repo => repo.Add(It.IsAny<string>())).Throws<Exception>();

            Assert.ThrowsAsync<Exception>(async () => await unitOfWork.Add(property.ToString()));
        }

        [Test]
        public async Task Delete_ShouldCallRepositoryDelete()
        {
            await unitOfWork.Delete(property.Id);

            repoMock.Verify(repo => repo.Delete(property.Id), Times.Once);
        }

        [Test]
        public void Delete_ShouldFail_WhenRepositoryDelete_ThrowsException()
        {
            repoMock.Setup(repo => repo.Delete(It.IsAny<Guid>())).Throws<Exception>();

            Assert.ThrowsAsync<Exception>(async () => await unitOfWork.Delete(property.Id));
        }

        [Test]
        public async Task Get_ShouldCallRepositoryGet()
        {
            await unitOfWork.Get(property.Id);

            repoMock.Verify(repo => repo.Get(property.Id), Times.Once);
        }

        [Test]
        public void Get_ShouldFail_WhenRepositoryGet_ThrowsException()
        {
            repoMock.Setup(repo => repo.Get(It.IsAny<Guid>())).Throws<Exception>();

            Assert.ThrowsAsync<Exception>(async () => await unitOfWork.Get(property.Id));
        }

        [Test]
        public async Task GetAll_ShouldCallRepositoryGetAll()
        {
            await unitOfWork.GetAll();

            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Test]
        public void GetAll_ShouldFail_WhenRepositoryGetAll_ThrowsException()
        {
            repoMock.Setup(repo => repo.GetAll()).Throws<Exception>();

            Assert.ThrowsAsync<Exception>(async () => await unitOfWork.GetAll());
        }

        [Test]
        public void Update_ShouldCallRepositoryUpdate()
        {
            unitOfWork.Update(property.ToString());

            repoMock.Verify(repo => repo.Update(property.ToString()), Times.Once);
        }

        [Test]
        public void Update_ShouldFail_WhenRepositoryUpdate_ThrowsException()
        {
            repoMock.Setup(repo => repo.Update(It.IsAny<string>())).Throws<Exception>();

            Assert.Throws<Exception>(() => unitOfWork.Update(property.ToString()));
        }
    }
}
