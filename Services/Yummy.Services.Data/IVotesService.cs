namespace Yummy.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(int recipeId, string userId, byte value);

        double RecipeVotesAvg(int recipeId);
    }
}
