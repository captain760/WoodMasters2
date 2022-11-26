using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Core.Data.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private List<Category> SeedCategories()
        {
            var categories = new List<Category>();
            var category = new Category()
            {
                Id = 1,
                Name = "Woodcarving"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Woodturning"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Pyrography"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Intarsia"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Scrow Sawing"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Cabinetry and Furniture"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 7,
                Name = "Carpentry and Joinery"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 8,
                Name = "Construction"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 9,
                Name = "Miscelaneous"
            };
            categories.Add(category);

            return categories;
        }
           
    }
}
