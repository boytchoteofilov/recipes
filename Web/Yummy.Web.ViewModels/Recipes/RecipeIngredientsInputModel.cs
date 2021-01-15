namespace Yummy.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;

    using Yummy.Data.Models;
    using Yummy.Services.Mapping;

    public class RecipeIngredientsInputModel : IMapFrom<RecipeIngredient>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string IngredientName { get; set; }

        [Required]
        [MinLength(1)]
        public string IngredientQuantity { get; set; }
    }
}
