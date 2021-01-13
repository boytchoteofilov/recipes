namespace Yummy.Services.Data.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICategoriesService
    {
        IEnumerable<T> All<T>();
    }
}
