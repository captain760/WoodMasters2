using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodMasters2.Core.Contracts
{
    public interface IRatingService
    {
        Task PostRatingAsync(int rating, int mid);
    }
}
