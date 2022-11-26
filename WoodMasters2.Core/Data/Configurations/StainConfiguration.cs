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
    internal class StainConfiguration : IEntityTypeConfiguration<Stain>
    {
        public void Configure(EntityTypeBuilder<Stain> builder)
        {
            builder.HasData(SeedStains());
        }

        private List<Stain> SeedStains()
        {
            var stains = new List<Stain>();
            var stain = new Stain()
            {
                Id = 1,
                Name = "Clear Coat"
            };
            stains.Add(stain);

            stain = new Stain()
            {
                Id = 2,
                Name = "Exotic Redwood"
            };
            stains.Add(stain);

            stain = new Stain()
            {
                Id = 3,
                Name = "Vintage Modern"
            };
            stains.Add(stain);

            stain = new Stain()
            {
                Id = 4,
                Name = "Golden Sunset"
            };
            stains.Add(stain);

            stain = new Stain()
            {
                Id = 5,
                Name = "Mocha"
            };
            stains.Add(stain);

            stain = new Stain()
            {
                Id = 6,
                Name = "Maroccan Red"
            };
            stains.Add(stain);

            stain = new Stain()
            {
                Id = 7,
                Name = "Silk Grey"
            };
            stains.Add(stain);

            stain = new Stain()
            {
                Id = 8,
                Name = "Whitish"
            };
            stains.Add(stain);

            return stains;
        }
    }
}
