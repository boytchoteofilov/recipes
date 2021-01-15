namespace Yummy.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment env;

        public RecipesController(
            ICategoriesService categoriesService,
            IRecipeService recipeService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment env)
        {
            this.categoriesService = categoriesService;
            this.recipeService = recipeService;
            this.userManager = userManager;
            this.env = env;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

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

        public IActionResult ById(int id)
        {
            var singleRecipe = this.recipeService.GetById<SingleRecipeViewModel>(id);
            return this.View(singleRecipe);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
            var vm = this.recipeService.GetById<RecipeEditInputModel>(id);

            vm.Categories = categories;

            return this.View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();

                return this.View(input);
            }

            await this.recipeService.UpdateRecipeAsync(input);

            return this.RedirectToAction(nameof(this.ById), new { input.Id });
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
            var vm = new RecipeCreateInputModel()
            {
                Categories = categories,
            };

            return this.View(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(RecipeCreateInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
                return this.View(input);
            }

            // user taken from the cookie
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            var webRoot = this.env.WebRootPath;

            try
            {
                await this.recipeService.CreateRecipeAsync(input, user.Id, webRoot);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.InnerException.ToString());
                input.Categories = this.categoriesService.GetAll<CategoriesForDropdownMenuIM>();
                return this.View(input);
            }

            ////TODO: redirect to show the recipe
            return this.Redirect("/");
        }
    }
}
