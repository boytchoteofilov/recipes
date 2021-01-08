namespace Yummy.Web.ViewModels.Recipes
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeIngredientsInputModel
    {
        [Required]
        [MinLength(3)]
        public string IngredientName { get; set; }

        [Required]
        [MinLength(1)]
        public string IngredientQuantity { get; set; }
    }
}
