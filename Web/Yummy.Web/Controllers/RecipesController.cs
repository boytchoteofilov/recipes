namespace Yummy.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Yummy.Web.ViewModels.Recipes;
    using Yummy.Services.Data;
    using Yummy.Web.ViewModels.Categories;

    public class RecipesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public RecipesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
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
        public IActionResult Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            return this.RedirectToAction("/");
        }
    }
}
