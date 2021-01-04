namespace Yummy.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Yummy.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
       Task AddRecipeAsync(CreateRecipeInputModel input, string userId);

       IEnumerable<T> AllPaged<T>(int page, int itemsPerPage);
    }
}
