namespace Yummy.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using AutoMapper;
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;
    using Yummy.Web.ViewModels.Categories;

    public class EditRecipeInputModel : IMapFrom<Recipe>/*, IHaveCustomMappings*/
    {
        public int RecipeId { get; set; }

        [Required]
        [MinLength(6)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Instructions { get; set; }

        [Range(1, 300)]
        [Display(Name = "Preparation Time (in minutes)")]
        public int PreparationTime { get; set; }

        [Range(1, 300)]
        [Display(Name = "Cooking Time (in minutes)")]
        public int CookingTime { get; set; }

        [Range(1, 12)]
        public int PortionsCount { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public IEnumerable<RecipeIngredientsInputModel> Ingredients { get; set; }

        public IEnumerable<CategoriesForDropdownMenuIM> Categories { get; set; }

        //public void CreateMappings(IProfileExpression configuration)
        //{
        //    configuration.CreateMap<Recipe, EditRecipeInputModel>()
        //        .ForMember(r => r.CookingTime, opt => opt.MapFrom(x => x.CookingTime.TotalMinutes))
        //        .ForMember(r => r.PreparationTime, opt => opt.MapFrom(x => x.PreparationTime.TotalMinutes));
        //}
    }
}
