namespace Yummy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Yummy.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
        Task CreateRecipeAsync(CreateRecipeInputModel input, string userId);

        Task UpdateRecipeAsync(EditRecipeInputModel input);

        IEnumerable<T> AllPaged<T>(int page, int itemsPerPage);

        IEnumerable<T> All<T>();

        EditRecipeInputModel ById(int recipeId);
    }
}
