using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeAHike.Models;
using TakeAHike.Repositories;

namespace TakeAHike.Controllers
{
    public class HomeController : Controller
    {
        private IHikeRepository repo;

        public HomeController(IHikeRepository r)
        {
            repo = r;
        }

        public IActionResult Index()    //using ViewBag and ViewData to send info from controller to index view
        {
            List<Hike> hikes = repo.Hikes;
            //ViewData["newestHike"] = hikes[hikes.Count - 1].TrailName;  //Doesn't work!!!the hikes sort by region before this is figured out, screwing up the newest hike!
            ViewBag.hikeCount = hikes.Count;
            return View(hikes);
        }
    }
}
