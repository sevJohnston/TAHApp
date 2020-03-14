using System;
using TakeAHike.Controllers;
using TakeAHike.Models;
using TakeAHike.Repositories;
using Xunit;

namespace TakeAHike.Tests
{
    public class HikesTests
    {
        [Fact]
        public void AddHikeTest()
        {
            //arrange
            var repo = new FakeHikeRepository();
            var homeController = new HomeController(repo);
            var h = new Hike
            {
                TrailName = "Mt Pisgah Summit",
                Region = "Willamette Valley",
                Description = "Great local hike for exercise and views.",
            };

            //act
            repo.AddHike(h);

            //assert
            Assert.Equal("Mt Pisgah Summit",
                repo.Hikes[repo.Hikes.Count - 1].TrailName);
            //this also tests the constructor- 3 hikes in test data + hike 4
            Assert.Equal(4, repo.Hikes.Count);
        }

        [Fact]
        public void TestGetHikeByRegion()
        {
            //arrange
            var repo = new FakeHikeRepository();
            var homeController = new HomeController(repo);

            //act
            var x = repo.GetHikeByRegion("Coast");

            //assert
            Assert.Equal("Cook's Ridge", x.TrailName);
        }

        [Fact]
        public void TestGetHikeByTrailName()
        {
            //arrange
            var repo = new FakeHikeRepository();
            var homeController = new HomeController(repo);

            //act
            var h = repo.GetHikeByTrailName("Fall Creek Falls");

            //assert
            Assert.Equal("Southern Oregon", h.Region);
        }
    }
}
