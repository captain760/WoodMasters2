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
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(SeedCountries());
        }
        private List<Country> SeedCountries()
        {
            var countries = new List<Country>();
            var country = new Country()
            {
                Id = 1,
                Name = "Bulgaria"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 2,
                Name = "Romania"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 3,
                Name = "Greece"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 4,
                Name = "Serbia"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 5,
                Name = "Turkey"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 6,
                Name = "Brazil"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 7,
                Name = "Russia"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 8,
                Name = "Ukraine"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 9,
                Name = "USA"
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 10,
                Name = "Canada"
            };
            countries.Add(country);

            return countries;
        }
    }
}
