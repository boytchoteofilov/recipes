namespace Yummy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Yummy.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
        Task CreateRecipeAsync(CreateRecipeInputModel input, string userId, string webRoot);

        Task UpdateRecipeAsync(EditRecipeInputModel input);

        T GetById<T>(int id);

        IEnumerable<T> AllPaged<T>(int page, int itemsPerPage);

        IEnumerable<T> All<T>();

        IEnumerable<T> Random<T>(int count);
    }
}
