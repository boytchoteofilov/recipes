namespace Yummy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Yummy.Data.Common.Repositories;
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;
    using Yummy.Web.ViewModels.Recipes;

    public class RecipeService : IRecipeService
    {
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRepository;

        public RecipeService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Ingredient> ingredientsRepository)
        {
            this.recipesRepository = recipesRepository;
            this.ingredientsRepository = ingredientsRepository;
        }

        public async Task AddRecipeAsync(CreateRecipeInputModel input, string userId)
        {
            var recipe = new Recipe()
            {
                CategoryId = input.CategoryId,
                Name = input.Name,
                Instructions = input.Instructions,
                PortionsCount = input.PortionsCount,
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                CookingTime = TimeSpan.FromMinutes(input.CookingTime),
                AddedByUserId = userId,
            };

            foreach (var ingredientItem in input.Ingredients)
            {
                var ingredient = this.ingredientsRepository.AllAsNoTracking().FirstOrDefault(x => x.Name == ingredientItem.IngredientName);
                if (ingredient == null)
                {
                    ingredient = new Ingredient()
                    {
                        Name = ingredientItem.IngredientName,
                    };
                }

                recipe.Ingredients.Add(new RecipeIngredient()
                {
                    Ingredient = ingredient,
                    Quantity = ingredientItem.IngredientQuantity,
                });
            }

            await this.recipesRepository.AddAsync(recipe);
            await this.recipesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> AllPaged<T>(int page, int itemsPerPage)
        {
            // must be sorted in order to use Skip() and Take()
            var recipesPerPage = this.recipesRepository
                .AllAsNoTracking().OrderByDescending(x => x.Id)
                .Skip(itemsPerPage * (page - 1))
                .Take(itemsPerPage)
                .To<T>()

                // use automapper instead
                // .Select(x => new RecipesInListViewModel()
                // {
                //    Id = x.Id,
                //    Name = x.Name,
                //    Instructions = x.Instructions,
                //    CategoryId = x.CategoryId,
                //    CategoryName = x.Category.Name,
                //    ImageOriginalUrl =
                //        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                //        x.Images.FirstOrDefault().RemoteImageUrl :
                //        "images/recipes/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension,
                // } )
                .ToList();

            return recipesPerPage;
        }
    }
}
