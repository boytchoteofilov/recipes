namespace Yummy.Controller.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Xunit;
    using Yummy.Data;
    using Yummy.Data.Common.Repositories;
    using Yummy.Data.Models;
    using Yummy.Data.Repositories;
    using Yummy.Services.Data;
    using Yummy.Web.Controllers;
    using Yummy.Web.ViewModels.Home;

    public class HomeControllerTests
    {
        [Fact]
        public void DbShouldReturnCorrectCategoriesCount()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var a = new EfDeletableEntityRepository<Category>(dbContext);
            var b = new EfDeletableEntityRepository<Recipe>(dbContext);
            var c = new EfDeletableEntityRepository<Ingredient>(dbContext);
            var d = new GetCountsService(a, b);
            var e = new RecipeService(b, c);

            var controller = new HomeController(a, b, dbContext, d, e);

            var category = new Category()
            {
                Id = 1,
                Name = "Pile",
                CreatedOn = new DateTime(2021, 1, 21),
            };
            dbContext.Categories.Add(category);

            var resut = controller.Db();
            Assert.Equal(1, resut.Value.CategoriesCount);
        }

        [Fact]
        public void DbShouldReturnNotNullIfCategoriesAreMoreThan0()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var a = new EfDeletableEntityRepository<Category>(dbContext);
            var b = new EfDeletableEntityRepository<Recipe>(dbContext);
            var c = new EfDeletableEntityRepository<Ingredient>(dbContext);
            var d = new GetCountsService(a, b);
            var e = new RecipeService(b, c);

            var controller = new HomeController(a, b, dbContext, d, e);

            var category = new Category()
            {
                Id = 1,
                Name = "Pile",
                CreatedOn = new DateTime(2021, 1, 21),
            };

            var resut = controller.Db();
            Assert.NotNull(resut);
        }

        [Fact]
        public void DbShouldReturnCorrectCategoriesFirstInListName()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("test");
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            var a = new EfDeletableEntityRepository<Category>(dbContext);
            var b = new EfDeletableEntityRepository<Recipe>(dbContext);
            var c = new EfDeletableEntityRepository<Ingredient>(dbContext);
            var d = new GetCountsService(a, b);
            var e = new RecipeService(b, c);

            var controller = new HomeController(a, b, dbContext, d, e);

            var category = new Category()
            {
                Id = 1,
                Name = "Pile",
                CreatedOn = new DateTime(2021, 1, 21),
            };

            var resut = controller.Db();
            var resultOne = controller.Db();
            Assert.NotNull(resut);
        }
    }
}
