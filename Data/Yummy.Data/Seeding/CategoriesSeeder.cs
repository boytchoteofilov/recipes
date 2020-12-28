namespace Yummy.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Yummy.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Cake" });
            await dbContext.Categories.AddAsync(new Category { Name = "Bake" });
            await dbContext.Categories.AddAsync(new Category { Name = "Make" });

            await dbContext.SaveChangesAsync();
        }
    }
}
