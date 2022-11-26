using Microsoft.AspNetCore.Identity;
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
    internal class UserConfiguration : IEntityTypeConfiguration<Master>
    {
        public void Configure(EntityTypeBuilder<Master> builder)
        {
            builder.HasData(SeedUsers());
        }
        private List<Master> SeedUsers()
        {
            var masters = new List<Master>();
            var hasher = new PasswordHasher<Master>();

            var master= new Master()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "Momo12",
                NormalizedUserName = "MOMO12",
                Email = "m_eftimov@yahoo.com",
                NormalizedEmail = "M_EFTIMOV@YAHOO.COM",
                FirstName = "Momchil",
                LastName = "Eftimov"
            };

            master.PasswordHash =
            hasher.HashPassword(master, "12momo");
            masters.Add(master);

            master = new Master()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "captain76",
                NormalizedUserName = "CAPTAIN76",
                Email = "b_eftimov@yahoo.com",
                NormalizedEmail = "B_EFTIMOV@YAHOO.COM",
                FirstName = "Boris",
                LastName = "Eftimov"
            };

            master.PasswordHash =
            hasher.HashPassword(master, "76captain");
            masters.Add(master);

            return masters;
        }

    }
}
