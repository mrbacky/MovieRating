using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieRating.Core;
using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Reviewer re1 = new Reviewer { Id = 21 };
            Movie m1 = new Movie { Id = 12 };

            List<Review> allReviews = new List<Review>
            {
                new Review { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re1 },
                new Review {Date = DateTime.Parse("2005-11-09"), Grade = 4, Movie = m1, Reviewer = re1  },
                new Review {Date = DateTime.Parse("2006-11-09"), Grade = 3, Movie = m1, Reviewer = re1 },
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            double actualResult = service.GetAverageRateFromReviewer(re1.Id);
            m.Verify(m => m.GetAllReviews(), Times.Once);
            Assert.IsTrue(actualResult == 4);
        }

        [TestMethod()]
        public void GetAverageRateOfMovieTest()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();
            IRatingService service = new RatingService(m.Object);
            Reviewer re1 = new Reviewer { Id = 12 };
            Movie m1 = new Movie { Id = 20 };
            Movie m2 = new Movie {Id = 15};

            List<Review> allReviews = new List<Review>
            {
                new Review { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m1, Reviewer = re1 },
                new Review {Date = DateTime.Parse("2005-11-09"), Grade = 4, Movie = m1, Reviewer = re1  },
                new Review {Date = DateTime.Parse("2006-11-09"), Grade = 2, Movie = m1, Reviewer = re1 },
                new Review { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m1, Reviewer = re1 },
                new Review {Date = DateTime.Parse("2005-11-09"), Grade = 5, Movie = m2, Reviewer = re1  },
                new Review {Date = DateTime.Parse("2006-11-09"), Grade = 2, Movie = m2, Reviewer = re1 }
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            double actualResult = service.GetAverageRateOfMovie(m1.Id);
            m.Verify(m => m.GetAllReviews(), Times.Once);
            Assert.IsTrue(actualResult ==3);
        }

        [TestMethod()]
        public void GetMostProductiveReviewersTest()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();
            IRatingService service = new RatingService(m.Object);
            Reviewer re1 = new Reviewer { Id = 12 };
            Reviewer re2 = new Reviewer { Id = 15 };
            Movie m1 = new Movie { Id = 20 };
            Movie m2 = new Movie { Id = 15 };

            List<Review> allReviews = new List<Review>
            {
                new Review { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m1, Reviewer = re1 },
                new Review {Date = DateTime.Parse("2005-11-09"), Grade = 4, Movie = m1, Reviewer = re1  },
                new Review {Date = DateTime.Parse("2006-11-09"), Grade = 2, Movie = m1, Reviewer = re1 },
                new Review { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m1, Reviewer = re1 },
                new Review {Date = DateTime.Parse("2005-11-09"), Grade = 5, Movie = m2, Reviewer = re2  },
                new Review {Date = DateTime.Parse("2006-11-09"), Grade = 2, Movie = m2, Reviewer = re2 }
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            List<int> actualResult = service.GetMostProductiveReviewers();

            Assert.IsTrue(actualResult.Count == 2);
            Assert.IsTrue(actualResult[0] == allReviews[2].Reviewer.Id);
            Assert.IsTrue(actualResult[1] == allReviews[4].Reviewer.Id);
          
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

            allReviews.AddRange(m1.Reviews);
            allReviews.AddRange(m2.Reviews);
            allReviews.AddRange(m3.Reviews);


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
            //  arrange

            var m = new Mock<IRatingRepository>();
            var service = new RatingService(m.Object);

            var allReviews = new List<Review>();

            var re1 = new Reviewer { Id = 21 };
            var re2 = new Reviewer { Id = 22 };
            var re3 = new Reviewer { Id = 23 };

            var m1 = new Movie { Id = 1 };
            var m2 = new Movie { Id = 2 };
            var m3 = new Movie { Id = 3 };
            var m4 = new Movie { Id = 4 };
            var m5 = new Movie { Id = 5 };
            var m6 = new Movie { Id = 6 };
            var m7 = new Movie { Id = 7 };

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 5, Movie = m1, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-06"), Grade = 5, Movie = m2, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-13"), Grade = 4, Movie = m3, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-02"), Grade = 4, Movie = m4, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m5, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m6, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-10"), Grade = 3, Movie = m7, Reviewer = re1 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 5, Movie = m1, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-09"), Grade = 4, Movie = m2, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 4, Movie = m3, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-05"), Grade = 1, Movie = m4, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-08"), Grade = 1, Movie = m5, Reviewer = re2 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-12"), Grade = 5, Movie = m4, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-11"), Grade = 4, Movie = m3, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-09"), Grade = 4, Movie = m5, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m2, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m1, Reviewer = re3 });

            //  act
            m.Setup(m => m.GetAllReviews()).Returns(() => allReviews);
            List<int> actualResult = service.GetTopMoviesByReviewer(re3.Id);
            m.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult.ElementAt(0) == 4);
            Assert.IsTrue(actualResult.ElementAt(1) == 3);
            Assert.IsTrue(actualResult.ElementAt(2) == 5);
            Assert.IsTrue(actualResult.ElementAt(3) == 1);
            Assert.IsTrue(actualResult.ElementAt(4) == 2);


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