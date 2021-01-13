namespace Yummy.Web.ViewModels.Administration.Categories
{
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;

    public class CategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
