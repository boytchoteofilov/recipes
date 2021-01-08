namespace Yummy.Web.ViewModels.Recipes
{
    using System.Collections.Generic;

    using Yummy.Web.ViewModels.Paging;

    public class RecipesListViewModel : PagingViewModel
    {
        public IEnumerable<RecipesInListViewModel> Recipes { get; set; }
    }
}
