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
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(SeedSuppliers());
        }
        private List<Supplier> SeedSuppliers()
        {
            var suppliers = new List<Supplier>();
            var supplier = new Supplier()
            {
                Id = 1,
                Name = "Bari Trans LTD"
            };
            suppliers.Add(supplier);

            supplier = new Supplier()
            {
                Id = 2,
                Name = "Ilza LTD"
            };
            suppliers.Add(supplier);

            supplier = new Supplier()
            {
                Id = 3,
                Name = "KoronaIm LTD"
            };
            suppliers.Add(supplier);

            supplier = new Supplier()
            {
                Id = 4,
                Name = "Hardi LTD"
            };
            suppliers.Add(supplier);

            supplier = new Supplier()
            {
                Id = 5,
                Name = "JAF Bulgaria"
            };
            suppliers.Add(supplier);

            supplier = new Supplier()
            {
                Id = 6,
                Name = "Centaur LTD"
            };
            suppliers.Add(supplier);


            return suppliers;
        }
    }
}
