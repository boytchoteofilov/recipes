namespace Yummy.Web.ViewModels.Ingredients
{
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;

    public class IngredientsViewModel : IMapFrom<RecipeIngredient>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }
    }
}
