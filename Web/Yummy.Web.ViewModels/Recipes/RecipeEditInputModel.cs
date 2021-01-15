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
    using Yummy.Web.ViewModels.Ingredients;

    public class RecipeEditInputModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, RecipeEditInputModel>()
                .ForMember(r => r.CookingTime, opt => opt.MapFrom(x => (int)x.CookingTime.TotalMinutes))
                .ForMember(r => r.PreparationTime, opt => opt.MapFrom(x => (int)x.PreparationTime.TotalMinutes));
        }
    }
}
