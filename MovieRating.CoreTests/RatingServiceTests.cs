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

            Reviewer re1 = new Reviewer { Id = 9 };
            Reviewer re2 = new Reviewer { Id = 88 };

            List<Review> allReviews = new List<Review>();
            re1.Reviews = new List<Review>();

            Movie m1 = new Movie { Id = 1 };
            Movie m2 = new Movie { Id = 2 };
            Movie m3 = new Movie { Id = 3 };
            Movie m4 = new Movie { Id = 4 };
            Movie m5 = new Movie { Id = 5 };

            Review r1 = new Review()
            {
                Date = DateTime.Parse("2004-11-09"),
                Grade = 2,
                Movie = m1,
                Reviewer = re1
            };

            Review r2 = new Review()
            {
                Date = DateTime.Parse("2005-11-09"),
                Grade = 5,
                Movie = m2,
                Reviewer = re1
            };

            Review r3 = new Review()
            {
                Date = DateTime.Parse("2006-11-09"),
                Grade = 3,
                Movie = m3,
                Reviewer = re1
            };
            Review r4 = new Review()
            {
                Date = DateTime.Parse("2006-11-09"),
                Grade = 3,
                Movie = m5,
                Reviewer = re2
            };
            Review r5 = new Review()
            {
                Date = DateTime.Parse("2006-11-09"),
                Grade = 1,
                Movie = m4,
                Reviewer = re2
            };

            allReviews.Add(r1);
            allReviews.Add(r2);
            allReviews.Add(r3);
            allReviews.Add(r4);
            allReviews.Add(r5);

            re1.Reviews.Add(r1);
            re1.Reviews.Add(r2);
            re1.Reviews.Add(r3);

            m.Setup(m => m.GetAll()).Returns(() => allReviews);

            int actualResult = service.GetNumberOfReviewsFromReviewer(re1.Id);
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.IsTrue(re1.Reviews.Count == 3);
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