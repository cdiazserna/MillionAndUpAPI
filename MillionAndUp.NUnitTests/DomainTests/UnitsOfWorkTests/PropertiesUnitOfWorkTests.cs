using MillionAndUp.Domain.Interfaces;
using MillionAndUp.Domain.UnitsOfWork;
using MillionAndUp.Models;
using Moq;

namespace MillionAndUp.NUnitTests.DomainTests.UnitsOfWorkTests
{
    [TestFixture]
    public class PropertiesUnitOfWorkTests
    {
        private Mock<IGenericRepository<Property>> repoMock;
        private IPropertiesUnitOfWork unitOfWork;
        private Random random;
        private PropertyFiltersPayload payload;

        [SetUp]
        public void Setup()
        {
            repoMock = new Mock<IGenericRepository<Property>>();
            unitOfWork = new PropertiesUnitOfWork(repoMock.Object);
            random = new Random();
            payload = new PropertyFiltersPayload
            {
                Address = "Test Address",
                MinPrice = random.Next(0, 5000),
                MaxPrice = random.Next(5001, 1000000),
                CodeInternal = "Test Code Internal",
            };
        }

        [Test]
        public async Task GetPropertiesByFilter_ShouldCallRepositoryExecuteStoreProcedure()
        {
            var expectedParameters = new List<ExecuteParameter>
            {
                new ExecuteParameter { Name = "Address", Value = payload.Address },
                new ExecuteParameter { Name = "MinPrice", Value = payload.MinPrice },
                new ExecuteParameter { Name = "MaxPrice", Value = payload.MaxPrice },
                new ExecuteParameter { Name = "CodeInternal", Value = payload.CodeInternal }
            };

            await unitOfWork.GetPropertiesByFilter(payload);

            repoMock.Verify(repo => repo.ExecuteStoreProcedure<PropertyFiltersDTO>("getPropertiesByFilter", It.IsAny<List<ExecuteParameter>>()), Times.Once);
        }

        [Test]
        public void GetPropertiesByFilter_ShouldFail_WhenRepositoryExecuteStoreProcedure_ThrowsException()
        {
            repoMock.Setup(repo => repo.ExecuteStoreProcedure<PropertyFiltersDTO>(It.IsAny<string>(), It.IsAny<List<ExecuteParameter>>()))
                .Throws<Exception>();

            Assert.ThrowsAsync<Exception>(async () => await unitOfWork.GetPropertiesByFilter(payload));
        }
    }
}
