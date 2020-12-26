namespace MoiteRecepti.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using MoiteRecepti.Data;
    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Data.Repositories;
    using MoiteRecepti.Services.Data;
    using MoiteRecepti.Web.ViewModels;
    using MoiteRecepti.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        // 1. DbContext
        // 2. Repositories
        // 3. Services
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly ApplicationDbContext db;
        private readonly IGetCountsService countsService;

        public HomeController(
            IDeletableEntityRepository<Category> categoriesRepository,
            IDeletableEntityRepository<Recipe> recipesRepository,
            ApplicationDbContext db,
            IGetCountsService countsService)
        {
            this.categoriesRepository = categoriesRepository;
            this.recipesRepository = recipesRepository;
            this.db = db;
            this.countsService = countsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                RecepiesCount = this.recipesRepository.All().Count(),
            };

            return this.View(viewModel);
        }

        public IActionResult Db()
        {
            var viewModel = new DbViewModel()
            {
                CategoriesCount = this.db.Categories.Count(),
            };

            return this.View(viewModel);
        }

        public IActionResult Service()
        {
            var vm = this.countsService.GetCounts();

            return this.View(vm);
        }

        public IActionResult ServiceDto()
        {
            var data = this.countsService.GetCountsFromDTO();

            var viewmodel = new ServiceViewModel()
            {
            CategoriesCount = data.CategoriesCount,
            RecipesCount = data.RecipesCount,
            };

            return this.View(viewmodel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
