namespace Yummy.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xunit;
    using Yummy.Data.Common.Repositories;
    using Yummy.Data.Models;

    public class VotesServiceTests
    {
        [Fact]
        public async Task OnlyOneVotePerUserPerRecipeShouldBeAdded()
        {
            // Arrange
            var service = new VotesService(new FakeVotesRepository());

            // Act
            await service.VoteAsync(1, "1", 1);
            await service.VoteAsync(1, "1", 1);

            // Asser
            Assert.NotNull(service);
        }
    }

    public class FakeVotesRepository : IDeletableEntityRepository<Vote>
    {
        public Task AddAsync(Vote entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> AllAsNoTracking()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> AllAsNoTrackingWithDeleted()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vote> AllWithDeleted()
        {
            throw new NotImplementedException();
        }

        public void Delete(Vote entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void HardDelete(Vote entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public void Undelete(Vote entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Vote entity)
        {
            throw new NotImplementedException();
        }
    }
}
