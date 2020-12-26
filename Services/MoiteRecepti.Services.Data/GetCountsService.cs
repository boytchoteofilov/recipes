namespace MoiteRecepti.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Data.DTOs;
    using MoiteRecepti.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public GetCountsService(
             IDeletableEntityRepository<Category> categoriesRepository,
             IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.recipesRepository = recipesRepository;
        }

        public ServiceViewModel GetCounts()
        {
            var data = new ServiceViewModel()
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                RecipesCount = this.recipesRepository.All().Count(),
            };

            return data;
        }

        public CountsDTO GetCountsFromDTO()
        {
            var data = new CountsDTO()
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                RecipesCount = this.recipesRepository.All().Count(),
            };

            return data;
        }
    }
}
