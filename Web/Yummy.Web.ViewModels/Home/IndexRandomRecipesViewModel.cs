namespace Yummy.Web.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;
    using Yummy.Web.ViewModels.Recipes;

    public class IndexRandomRecipesViewModel : RecipesInListViewModel, IHaveCustomMappings
    {
        public string ImageUrlAddress { get; set; }

        // public int Id { get; set; }

        // public string Name { get; set; }

        // public string CategoryName { get; set; }
        public new void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, IndexRandomRecipesViewModel>()
                .ForMember(x => x.ImageUrlAddress, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "images/recipes/" + x.Images.FirstOrDefault().Id + x.Images.FirstOrDefault().Extension));
        }
    }
}
