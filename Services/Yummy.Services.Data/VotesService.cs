namespace Yummy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Yummy.Data.Common.Repositories;
    using Yummy.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IDeletableEntityRepository<Vote> votesRepository;

        public VotesService(IDeletableEntityRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double RecipeVotesAvg(int recipeId)
        {
            var recipeVotesAvg = this.votesRepository
                .All()
                .Where(x => x.RecipeId == recipeId)
                .Average(x => x.Value);

            return recipeVotesAvg;
        }

        public async Task VoteAsync(int recipeId, string userId, byte value)
        {
            // chek if there is a vote in the database
            // get the vote from the db
            var vote = this.votesRepository
                .All()
                .FirstOrDefault(x => x.RecipeId == recipeId && x.UserId == userId);

            // check if vote doesn't exist
            if (vote == null)
            {
                // then create one
                vote = new Vote()
                {
                    RecipeId = recipeId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;

            await this.votesRepository.SaveChangesAsync();
        }
    }
}
