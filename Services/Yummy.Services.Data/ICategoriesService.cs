namespace Yummy.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Yummy.Web.ViewModels.Categories;

    public interface ICategoriesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
