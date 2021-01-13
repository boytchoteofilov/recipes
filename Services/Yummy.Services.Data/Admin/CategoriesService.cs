namespace Yummy.Services.Data.Admin
{
    using System.Collections.Generic;
    using System.Linq;

    using Yummy.Data.Common.Repositories;
    using Yummy.Data.Models;
    using Yummy.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<T> All<T>()
        {
            var allCategories = this.categoriesRepository.All().To<T>().ToList();

            return allCategories;
        }
    }
}
