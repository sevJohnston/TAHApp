using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeAHike.Models;

namespace TakeAHike.Repositories
{
    public class HikeRepository : IHikeRepository
    {
        private AppDbContext context;

        private static List<Hike> hikes = new List<Hike>();
        public List<Hike> Hikes { get { return context.Hikes.ToList(); } }

        //constructor
        public HikeRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        //adding hike to dB
        public void AddHike(Hike hike)
        {
            context.Hikes.Add(hike);
            context.SaveChanges();
        }

        public Hike GetHikeByID(int hikeID)
        {
            Hike hike;
            hike = context.Hikes.First(h => h.HikeID == hikeID);
            return hike;
        }
        public Hike GetHikeByTrailName(string trailName)
        {
            Hike hike;
            //FirstOrDefault will return a default value if queried with a bad goodName--
            //so no exception is thrown
            hike = context.Hikes.FirstOrDefault(h => h.TrailName == trailName);
            return hike;
        }

        public Hike GetHikeByRegion(string region)
        {
            Hike hike;
            hike = context.Hikes.First(h => h.Region == region);
            return hike;
        }


    }
}
