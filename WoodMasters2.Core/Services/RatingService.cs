using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodMasters2.Core.Contracts;
using WoodMasters2.Core.Data;
using WoodMasters2.Core.Data.Entities;

namespace WoodMasters2.Core.Services
{
    public class RatingService : IRatingService
    {
        private readonly WMDbContext context;
        public RatingService(WMDbContext _context)
        {
            this.context = _context;
        }

        public async Task PostRatingAsync(int rating, int mid)
        {
            var rt = new StarRating()
            {
                Rate = rating,
                MasterPieceId = mid
            };
            await context.Ratings.AddAsync(rt);
            await context.SaveChangesAsync();
        }
    }
}
