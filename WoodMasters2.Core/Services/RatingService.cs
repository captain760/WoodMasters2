using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public void PostRatingAsync(int rating, int mid)
        {
            var rt = new StarRating();

            rt.Rate = rating;
            rt.MasterPieceId = mid;
            //context.Entry<StarRating>(rt).State = EntityState.Modified; // change the Tracker state
            //bool hasChanges = context.ChangeTracker.HasChanges(); // should be true
            //int updates = context.SaveChanges();                  // should be > 0

            // why the hell when it is async it is not tracking???

            context.Ratings.Add(rt);
            context.SaveChanges();
        }
    }
}
