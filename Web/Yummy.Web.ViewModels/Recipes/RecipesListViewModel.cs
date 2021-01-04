namespace Yummy.Web.ViewModels.Recipes
{
    using System.Collections.Generic;

    public class RecipesListViewModel
    {
        public IEnumerable<RecipesInListViewModel> Recipes { get; set; }

        public int PageNumber { get; set; }
    }
}
