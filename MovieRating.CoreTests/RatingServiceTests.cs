using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieRating.Core;
using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core.Tests
{
    [TestClass()]
    public class RatingServiceTests
    {

        [TestMethod()]
        public void GetAverageRateFromReviewerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAverageRateOfMovieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMostProductiveReviewersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetMoviesWithHighestNumberOfTopRatesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNumberOfRatesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNumberOfRatesByReviewerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNumberOfReviewsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetNumberOfReviewsFromReviewerTest()
        {

            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            IRatingService service = new RatingService(m.Object);

            List<Rating> r1Ratings = { };

            Movie m1 = new Movie { Id = 1, AvgRating = 3, Reviewers = };

            Reviewer re1 = new Reviewer{Id=1,Ratings}




        Rating rating1 = new Rating { }




        service.GetNumberOfReviewsFromReviewer(5);

            Assert.Fail();
        }

        [TestMethod()]
        public void GetReviewersByMovieTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTopMoviesByReviewerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTopRatedMoviesTest()
        {
            Assert.Fail();
        }
    }
}