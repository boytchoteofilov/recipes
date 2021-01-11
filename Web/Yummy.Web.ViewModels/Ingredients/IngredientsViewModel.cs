namespace Yummy.Web.ViewModels.Ingredients
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Yummy.Data.Models;
    using Yummy.Services.Mapping;

    public class IngredientsViewModel : IMapFrom<RecipeIngredient>
    {
        public string IngredientName { get; set; }

        public string Quantity { get; set; }
    }
}
