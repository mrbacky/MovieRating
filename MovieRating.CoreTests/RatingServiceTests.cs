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
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();
            IRatingService service = new RatingService(m.Object);

            List<Review> allReviews = new List<Review>();

            Reviewer re1 = new Reviewer { Id = 21 };
            Reviewer re2 = new Reviewer { Id = 15 };

            Movie m1 = new Movie { Id = 11 };

            Review r1 = new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re1 };
            Review r2 = new Review() { Date = DateTime.Parse("2005-11-09"), Grade = 4, Movie = m1, Reviewer = re1 };
            Review r3 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 3, Movie = m1, Reviewer = re1 };
            Review r4 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 3, Movie = m1, Reviewer = re2 };
            Review r5 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 1, Movie = m1, Reviewer = re2 };

            allReviews.Add(r1);
            allReviews.Add(r2);
            allReviews.Add(r3);
            allReviews.Add(r4);
            allReviews.Add(r5);

            re1.Reviews.Add(r1);
            re1.Reviews.Add(r2);
            re1.Reviews.Add(r3);
            re2.Reviews.Add(r4);
            re2.Reviews.Add(r5);

            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            double actualResult = service.GetAverageRateFromReviewer(21);

            m.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult == 4);
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
            //  arrange   
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();
            IRatingService service = new RatingService(m.Object);

            Reviewer re1 = new Reviewer { Id = 21 };
            Reviewer re2 = new Reviewer { Id = 22 };
            Reviewer re3 = new Reviewer { Id = 23 };
            Reviewer re4 = new Reviewer { Id = 24 };

            Movie m1 = new Movie { Id = 12 };
            Movie m2 = new Movie { Id = 44 };
            Movie m3 = new Movie { Id = 9 };

            m1.Reviews = new List<Review>()                     //  rating = 4
            {
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re1 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re2 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re3 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 1, Movie = m1, Reviewer = re4 }
            };
            m2.Reviews = new List<Review>()                     //  rating = 4.5                      
            {
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m2, Reviewer = re1 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m2, Reviewer = re2 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m2, Reviewer = re3 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m2, Reviewer = re4 }
            };
            m3.Reviews = new List<Review>()                     //  rating = 4     
            {
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m3, Reviewer = re1 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m3, Reviewer = re2 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m3, Reviewer = re3 },
                new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m3, Reviewer = re4 }
            };

            List<Review> allReviews = new List<Review>();


            //  act
            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            //  returning 2 top movies from all 3 movies
            List<int> actualResult = service.GetMoviesWithHighestNumberOfTopRates();
            m.Verify(m => m.GetAllReviews(), Times.Once);

            //  assert
            Assert.IsTrue(actualResult.Count == 2);
            Assert.IsTrue(actualResult.Contains(m1.Id));
            Assert.IsTrue(actualResult.Contains(m3.Id));






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
            //  arrange
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();
            IRatingService service = new RatingService(m.Object);

            List<Review> allReviews = new List<Review>();

            Reviewer re1 = new Reviewer { Id = 21 };
            Reviewer re2 = new Reviewer { Id = 22 };
            Reviewer re3 = new Reviewer { Id = 23 };
            Reviewer re4 = new Reviewer { Id = 24 };
            Reviewer re5 = new Reviewer { Id = 25 };

            Movie m1 = new Movie { Id = 1 };
            Movie m2 = new Movie { Id = 2 };

            m1.Reviews = new List<Review>();
            m2.Reviews = new List<Review>();

            Review r1 = new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 2, Movie = m1, Reviewer = re1 };
            Review r2 = new Review() { Date = DateTime.Parse("2005-11-09"), Grade = 5, Movie = m1, Reviewer = re2 };
            Review r3 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 3, Movie = m1, Reviewer = re3 };
            Review r4 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 3, Movie = m2, Reviewer = re4 };
            Review r5 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 1, Movie = m2, Reviewer = re5 };

            allReviews.Add(r1);
            allReviews.Add(r2);
            allReviews.Add(r3);
            allReviews.Add(r4);
            allReviews.Add(r5);

            m1.Reviews.Add(r1);
            m1.Reviews.Add(r2);
            m1.Reviews.Add(r3);

            m2.Reviews.Add(r4);
            m2.Reviews.Add(r5);

            //  act
            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            int actualResult = service.GetNumberOfReviews(m2.Id);
            m.Verify(m => m.GetAllReviews(), Times.Once);

            //  assert
            Assert.IsTrue(actualResult == 2);
            Assert.IsTrue(m2.Reviews.Count == 2);

        }

        [TestMethod()]
        public void GetNumberOfReviewsFromReviewerTest()
        {
            //  arrange
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            IRatingService service = new RatingService(m.Object);

            Reviewer re1 = new Reviewer { Id = 51 };
            Reviewer re2 = new Reviewer { Id = 52 };

            List<Review> allReviews = new List<Review>();
            re1.Reviews = new List<Review>();
            re2.Reviews = new List<Review>();

            Movie m1 = new Movie { Id = 1 };
            Movie m2 = new Movie { Id = 2 };
            Movie m3 = new Movie { Id = 3 };
            Movie m4 = new Movie { Id = 4 };
            Movie m5 = new Movie { Id = 5 };

            Review r1 = new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 2, Movie = m1, Reviewer = re1 };
            Review r2 = new Review() { Date = DateTime.Parse("2005-11-09"), Grade = 5, Movie = m2, Reviewer = re1 };
            Review r3 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 3, Movie = m3, Reviewer = re1 };
            Review r4 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 3, Movie = m4, Reviewer = re2 };
            Review r5 = new Review() { Date = DateTime.Parse("2006-11-09"), Grade = 1, Movie = m5, Reviewer = re2 };

            allReviews.Add(r1);
            allReviews.Add(r2);
            allReviews.Add(r3);
            allReviews.Add(r4);
            allReviews.Add(r5);

            re1.Reviews.Add(r1);
            re1.Reviews.Add(r2);
            re1.Reviews.Add(r3);

            re2.Reviews.Add(r4);
            re2.Reviews.Add(r5);

            //  act
            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            int actualResult = service.GetNumberOfReviewsFromReviewer(re2.Id);
            m.Verify(m => m.GetAllReviews(), Times.Once);

            //  assert
            Assert.IsTrue(re2.Reviews.Count == 2);
            Assert.IsTrue(actualResult == 2);
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
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            IRatingService service = new RatingService(m.Object);

            List<Movie> movies = new List<Movie>();


            Movie m1 = new Movie()
            {
                Id = 1,

                Rating = 1.0,

            };
            Movie m2 = new Movie()
            {
                Id = 2,

                Rating = 2.1,

            };
            Movie m3 = new Movie()
            {
                Id = 3,

                Rating = 4.8,

            };
            Movie m4 = new Movie()
            {
                Id = 4,

                Rating = 5.0,

            };
            Movie m5 = new Movie()
            {
                Id = 5,

                Rating = 4.9,

            };
            Movie m6 = new Movie()
            {
                Id = 6,

                Rating = 3.2,

            };

        }
    }

}