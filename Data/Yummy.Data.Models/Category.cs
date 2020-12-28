namespace Yummy.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Yummy.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
