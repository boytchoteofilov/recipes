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

        public async Task CreateRecipeAsync(CreateRecipeInputModel input, string userId)
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

        public async Task UpdateRecipeAsync(EditRecipeInputModel input)
        {
            var recipeToEdit = this.recipesRepository.All().Where(x => x.Id == input.RecipeId).FirstOrDefault();

            recipeToEdit.CategoryId = input.CategoryId;
            recipeToEdit.Name = input.Name;
            recipeToEdit.Instructions = input.Instructions;
            recipeToEdit.PortionsCount = input.PortionsCount;
            recipeToEdit.PreparationTime = TimeSpan.FromMinutes(input.PreparationTime);
            recipeToEdit.CookingTime = TimeSpan.FromMinutes(input.CookingTime);

            this.recipesRepository.Update(recipeToEdit);
            await this.recipesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> All<T>()
        {
            var recipes = this.recipesRepository.All().To<T>().ToList();

            return recipes;
        }

        public EditRecipeInputModel ById(int recipeId)
        {
            var singleRecipe = this.recipesRepository.All().Where(x => x.Id == recipeId).FirstOrDefault();

            var data = new EditRecipeInputModel()
            {
                RecipeId = singleRecipe.Id,
                Name = singleRecipe.Name,
                CategoryId = singleRecipe.CategoryId,
                CookingTime = (int)singleRecipe.CookingTime.TotalMinutes,
                PortionsCount = singleRecipe.PortionsCount,
                Instructions = singleRecipe.Instructions,
                //Ingredients = singleRecipe.Ingredients,
                PreparationTime = (int)singleRecipe.PreparationTime.TotalMinutes,

            };

            return data;
        }
    }
}
