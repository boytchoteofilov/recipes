namespace Yummy.Data.Models
{
    using Yummy.Data.Common.Models;

    public class RecipeIngredient : BaseDeletableModel<int>
    {
        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public string IngredientQuantity { get; set; }
    }
}
