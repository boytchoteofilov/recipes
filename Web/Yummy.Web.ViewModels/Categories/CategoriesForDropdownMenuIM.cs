namespace Yummy.Web.ViewModels.Categories
{
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;

    public class CategoriesForDropdownMenuIM : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
