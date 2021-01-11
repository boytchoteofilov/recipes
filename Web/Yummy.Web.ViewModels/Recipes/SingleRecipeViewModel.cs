namespace Yummy.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;
    using Yummy.Web.ViewModels.Ingredients;

    public class SingleRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Instructions { get; set; }

        public DateTime CreatedOn { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public int PortionsCount { get; set; }

        public string OriginalUrl { get; set; }

        public string AddedByUserUserName { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<IngredientsViewModel> Ingredients { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, SingleRecipeViewModel>()
                .ForMember(x => x.OriginalUrl, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "images/recipes/" + x.Images.FirstOrDefault().Id + x.Images.FirstOrDefault().Extension));
        }
    }
}
