namespace Yummy.Web.ViewModels.Paging
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PagingViewModel
    {
        public bool HasPrevious => this.CurrentPage > 1;

        public int PreviousPage => this.CurrentPage - 1;

        public int CurrentPage { get; set; }

        public int NextPage => this.CurrentPage + 1;

        public bool HasNext => this.CurrentPage < this.PagesCount;

        public int ItemsPerPage { get; set; }

        public int RecipesCount { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)this.RecipesCount/this.ItemsPerPage);
    }
}
