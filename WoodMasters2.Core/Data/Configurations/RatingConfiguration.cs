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
    internal class RatingConfiguration : IEntityTypeConfiguration<StarRating>
    {
        public void Configure(EntityTypeBuilder<StarRating> builder)
        {
            builder.HasData(SeedRatings());
        }

        private List<StarRating> SeedRatings()
        {
            var ratings = new List<StarRating>();
            var rating = new StarRating()
            {
                RateId = 1,
                MasterPieceId = 1,
                Rate = 3
            };
            ratings.Add(rating);

             rating = new StarRating()
            {
                RateId = 2,
                MasterPieceId = 2,
                Rate = 4
            };
            ratings.Add(rating);
             rating = new StarRating()
            {
                RateId = 3,
                MasterPieceId = 3,
                Rate = 5
            };
            ratings.Add(rating);
             rating = new StarRating()
            {
                RateId = 4,
                MasterPieceId = 4,
                Rate = 3
            };
            ratings.Add(rating);
             rating = new StarRating()
            {
                RateId = 5,
                MasterPieceId = 1,
                Rate = 5
            };
            ratings.Add(rating);
             rating = new StarRating()
            {
                RateId = 6,
                MasterPieceId = 3,
                Rate = 2
            };
            ratings.Add(rating);
            return ratings;
        }
    }
}
