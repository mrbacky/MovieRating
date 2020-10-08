using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using MovieRating.Core;
using MovieRating.Core.DomainServices;

namespace MSTest
{
    [TestClass]
    public class RatingServiceTest
    {
        [TestMethod]
        public void TestNumberOfReviewsFromReviewer()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 2},
                new Review {Reviewer = 1, Movie = 2, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);

            var actualResult = ratingService.GetNumberOfReviewsFromReviewer(1);

            m.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult == 2);
        }

        [TestMethod]
        public void TestAverageRateFromReviewer()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 2, Grade = 5},
                new Review {Reviewer = 3, Movie = 1, Grade = 1},
                new Review {Reviewer = 1, Movie = 1, Grade = 3},
                new Review {Reviewer = 1, Movie = 2, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);
            var ratingService = new RatingService(m.Object);
            var actualResult = ratingService.GetAverageRateFromReviewer(1);
            m.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult.Equals(4.333333333333333));
        }

        [TestMethod]
        public void TestNumberOfRatesByReviewer()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();
            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 3},
                new Review {Reviewer = 1, Movie = 1, Grade = 3},
                new Review {Reviewer = 1, Movie = 4, Grade = 3},
                new Review {Reviewer = 2, Movie = 2, Grade = 2},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);

            var actualResult = ratingService.GetNumberOfRatesByReviewer(1,3);
            m.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult == 3);
        }

        [TestMethod]
        public void TestNumberOfReviews()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 2},
                new Review {Reviewer = 1, Movie = 1, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
                new Review {Reviewer = 1, Movie = 3, Grade = 3},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);
            var actualResult = ratingService.GetNumberOfReviews(1);
            m.Verify(m => m.GetAllReviews(), Times.Once);
            Assert.IsTrue(actualResult == 3);
        }

        [TestMethod]
        public void TestAverageRateOfMovie()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 5},
                new Review {Reviewer = 1, Movie = 2, Grade = 3},
                new Review {Reviewer = 2, Movie = 1, Grade = 5},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);
            var ratingService = new RatingService(m.Object);
            var actualResult = ratingService.GetAverageRateOfMovie(1);
            m.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult.Equals(5));
        }

        [TestMethod]
        public void TestNumberOfRates()
        {
            //Arrange
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 1},
                new Review {Reviewer = 1, Movie = 2, Grade = 4},
                new Review {Reviewer = 1, Movie = 3, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);

            //Act
            var actualResult = ratingService.GetNumberOfRates(1, 1);

            //Assert
            m.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult == 2);
        }

        [TestMethod]
        public void TestMoviesWithHighestNumberOfTopRates()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 5},
                new Review {Reviewer = 1, Movie = 2, Grade = 4},
                new Review {Reviewer = 1, Movie = 3, Grade = 3},

                new Review {Reviewer = 2, Movie = 1, Grade = 5},
                new Review {Reviewer = 2, Movie = 2, Grade = 5},
                new Review {Reviewer = 2, Movie = 3, Grade = 5},

                new Review {Reviewer = 3, Movie = 1, Grade = 5},
                new Review {Reviewer = 3, Movie = 2, Grade = 4},
                new Review {Reviewer = 3, Movie = 3, Grade = 5},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);
            var ratingService = new RatingService(m.Object);
            var actualResult = ratingService.GetMoviesWithHighestNumberOfTopRates();

            var expectedResult = new List<int>() { 1, 3, 2 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestMostProductiveReviewers()
        {
            //Arrange
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 1},
                new Review {Reviewer = 1, Movie = 2, Grade = 4},
                new Review {Reviewer = 1, Movie = 3, Grade = 3},

                new Review {Reviewer = 2, Movie = 1, Grade = 1},

                new Review {Reviewer = 3, Movie = 1, Grade = 4},
                new Review {Reviewer = 3, Movie = 2, Grade = 4},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);
            var actualResult = ratingService.GetMostProductiveReviewers();
            m.Verify(m => m.GetAllReviews(), Times.Once);

            var expectedResult = new List<int>() { 1, 3, 2 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestTopRatedMovies()
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 5},
                new Review {Reviewer = 1, Movie = 2, Grade = 2},
                new Review {Reviewer = 1, Movie = 3, Grade = 3},

                new Review {Reviewer = 2, Movie = 1, Grade = 4},
                new Review {Reviewer = 2, Movie = 2, Grade = 4},

                new Review {Reviewer = 3, Movie = 2, Grade = 4},
                new Review {Reviewer = 3, Movie = 3, Grade = 4},
                new Review {Reviewer = 3, Movie = 4, Grade = 1},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);

            var actualResult = ratingService.GetTopRatedMovies(3);

            m.Verify(m => m.GetAllReviews(), Times.Once);

            var expectedResult = new List<int>() { 1, 3, 2 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        [TestMethod]
        public void TestTopMoviesByReviewer() 
        {
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();
            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 4, Date = DateTime.Parse("2020-03-11")},
                new Review {Reviewer = 1, Movie = 2, Grade = 5, Date = DateTime.Parse("2002-03-12")},
                new Review {Reviewer = 1, Movie = 3, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 2, Movie = 1, Grade = 3, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 2, Movie = 2, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 3, Movie = 2, Grade = 5, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 3, Movie = 3, Grade = 3, Date = DateTime.Parse("2020-03-12")},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);
            var actualResult = ratingService.GetTopMoviesByReviewer(1);

            m.Verify(m => m.GetAllReviews(), Times.Once);

            var expectedResult = new List<int>() { 2, 3, 1 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));

            Assert.IsTrue(actualResult.ElementAt(0) == 2);
            Assert.IsTrue(actualResult.ElementAt(1) == 3);
            Assert.IsTrue(actualResult.ElementAt(2) == 1);
        }

        [TestMethod]
        public void TestReviewersByMovie()
        {
           
            Mock<IRatingRepository> m = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 4, Date = DateTime.Parse("2020-03-11")},
                new Review {Reviewer = 1, Movie = 2, Grade = 5, Date = DateTime.Parse("2002-03-12")},
                new Review {Reviewer = 1, Movie = 3, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 2, Movie = 1, Grade = 4, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 2, Movie = 2, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 3, Movie = 2, Grade = 5, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 3, Movie = 3, Grade = 3, Date = DateTime.Parse("2020-03-12")},
            };

            m.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(m.Object);
            var actualResult = ratingService.GetReviewersByMovie(1);
            m.Verify(m => m.GetAllReviews(), Times.Once);
            var expectedResult = new List<int>() { 112, 111 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));

        }
    }
}
