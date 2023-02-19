using Data;
using Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mock
{
    public static class MockUnitOfWork
    {
       

        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<CandidateDbContext>()
                .UseInMemoryDatabase(databaseName: $"CandidateDbContext-{Guid.NewGuid()}")
                .Options;

            var FakeCandidateDbContext = new CandidateDbContext(options);
            FakeCandidateDbContext.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(FakeCandidateDbContext);                    

            return mockUnitOfWork;
        }

    }
}
