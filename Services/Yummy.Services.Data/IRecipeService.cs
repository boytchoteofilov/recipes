namespace Yummy.Services.Data
{
    using System.Threading.Tasks;

    using Yummy.Web.ViewModels.Recipes;

    public interface IRecipeService
    {
       Task AddRecipeAsync(CreateRecipeInputModel input);
    }
}
