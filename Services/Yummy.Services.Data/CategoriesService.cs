﻿namespace Yummy.Services.Data
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

        public IEnumerable<T> GetAll<T>()
        {
            var query = this.categoriesRepository.AllAsNoTracking().OrderBy(x => x.Name);

            var result = query.To<T>().ToList();

            return result;
        }
    }
}
