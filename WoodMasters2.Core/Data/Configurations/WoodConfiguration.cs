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
    internal class WoodConfiguration : IEntityTypeConfiguration<Wood>
    {
        public void Configure(EntityTypeBuilder<Wood> builder)
        {
            builder.HasData(SeedWoods());
        }
        private List<Wood> SeedWoods()
        {
            var woods = new List<Wood>();
            var wood = new Wood()
            {
                Id = 1,
                Type = "Oak"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 2,
                Type = "Walnut"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 3,
                Type = "Pine"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 4,
                Type = "Beech"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 5,
                Type = "Linden"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 6,
                Type = "Poplar"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 7,
                Type = "Birch"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 8,
                Type = "Cedar"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 9,
                Type = "Ash"
            };
            woods.Add(wood);

            wood = new Wood()
            {
                Id = 10,
                Type = "Acer"
            };
            woods.Add(wood);        
            

            return woods;
        }
    }
}
