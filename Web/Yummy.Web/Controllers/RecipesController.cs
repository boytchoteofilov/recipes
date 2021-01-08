namespace Yummy.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Yummy.Data.Models;
    using Yummy.Services.Data;
    using Yummy.Web.ViewModels.Categories;
    using Yummy.Web.ViewModels.Recipes;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;
        private readonly IRecipeService recipeService;
        private readonly UserManager<ApplicationUser> userManager;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipeService recipeService,
            UserManager<ApplicationUser> userManager)
        {
            this.categoriesService = categoriesService;
            this.recipeService = recipeService;
            this.userManager = userManager;
        }

        public IActionResult All(int id = 1)
        {
            var currentPage = id;
            var itemsPerPage = 12;
            var vm = new RecipesListViewModel()
            {
                ItemsPerPage = itemsPerPage,
                CurrentPage = currentPage,
                Recipes = this.recipeService.AllPaged<RecipesInListViewModel>(currentPage, itemsPerPage),
            };

            return this.View(vm);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
            var vm = this.recipeService.ById(id);

            return this.View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();

                return this.View(input);
            }

            await this.recipeService.UpdateRecipeAsync(input);

            return this.Redirect("/");
        }

        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
                return this.View(input);
            }

            // user taken from the cookie
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            await this.recipeService.CreateRecipeAsync(input, user.Id);

            ////TODO: redirect to show the recipe
            return this.Redirect("/");
        }
    }
}
