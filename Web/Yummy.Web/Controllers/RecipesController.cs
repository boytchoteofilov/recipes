namespace Yummy.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Yummy.Services.Data;
    using Yummy.Web.ViewModels.Categories;
    using Yummy.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipeService recipeService;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipeService recipeService)
        {
            this.categoriesService = categoriesService;
            this.recipeService = recipeService;
        }

        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
            var vm = new CreateRecipeInputModel()
            {
                Categories = categories,
            };

            return this.View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
                return this.View(input);
            }

            await this.recipeService.AddRecipeAsync(input);

            ////TODO: redirect to show the recipe
            return this.Redirect("/");
        }
    }
}
