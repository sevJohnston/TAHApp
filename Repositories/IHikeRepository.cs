using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeAHike.Models;

namespace TakeAHike.Repositories
{
    public interface IHikeRepository
    {
        List<Hike> Hikes { get; }
        void AddHike(Hike hike);
        Hike GetHikeByTrailName(string trailName);
        Hike GetHikeByRegion(string region);
    }
}
