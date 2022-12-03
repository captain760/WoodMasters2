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
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(SeedAddresses());
        }
        private List<Address> SeedAddresses()
        {
            var addresses = new List<Address>();
            var address = new Address()
            {
                Id = 1,
                PlaceName = "Varna, 37 Evlogi Georgiev str.",
                CountryId = 1                
            };
            addresses.Add(address);

            address = new Address()
            {
                Id = 2,
                PlaceName = "Sofia, 3 Musala str.",
                CountryId = 1
            };
            addresses.Add(address);

            

            return addresses;
        }
    }
}
