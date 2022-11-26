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
    internal class MasterAddressConfiguration : IEntityTypeConfiguration<MasterAddress>
    {
        public void Configure(EntityTypeBuilder<MasterAddress> builder)
        {
            builder.HasData(SeedMasterAddresses());
        }
        private List<MasterAddress> SeedMasterAddresses()
        {
            var masterAddresses = new List<MasterAddress>();
            var masterAddress = new MasterAddress()
            {
                MasterId = "dea12856-c198-4129-b3f3-b893d8395082",
                AddressId = 1
            };
            masterAddresses.Add(masterAddress);

            masterAddress = new MasterAddress()
            {
                MasterId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                AddressId = 2
            };
            masterAddresses.Add(masterAddress);

            return masterAddresses;
        }

    }
}
