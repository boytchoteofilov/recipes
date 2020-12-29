namespace Yummy.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Yummy.Web.ViewModels.Categories;

    public class CreateRecipeInputModel
    {
        //[Required]
        //[MinLength(6)]
        public string Name { get; set; }

        //[Required]
        //[MinLength(100)]
        public string Instructions { get; set; }

        //[Range(1, 300)]
        //[Display(Name = "Preparation Time (in minutes)")]
        public int PreparationTime { get; set; }

        //[Range(1, 300)]
        //[Display(Name = "Cooking Time (in minutes)")]
        public int CookingTime { get; set; }

        [Range(1, 12)]
        public int PortionsCount { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<RecipeIngredientsInputModel> Ingredients { get; set; }

        public IEnumerable<CategoriesForDropdownMenuIM> Categories { get; set; }
    }
}
