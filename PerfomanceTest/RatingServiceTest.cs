﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 111, Movie = 1, Grade = 2},
                new Review {Reviewer = 111, Movie = 2, Grade = 5},
                new Review {Reviewer = 112, Movie = 1, Grade = 1},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            var actualResult = ratingService.GetNumberOfReviewsFromReviewer(111);

            mock.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult == 2);
        }

        [TestMethod]
        public void TestAverageRateFromReviewer()
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 2},
                new Review {Reviewer = 1, Movie = 2, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);
            var actualResult = ratingService.GetAverageRateFromReviewer(1);
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult.Equals(3.5), "Average rate is not 3.5.");
        }

        [TestMethod]
        public void TestNumberOfRatesByReviewer()
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 2},
                new Review {Reviewer = 1, Movie = 2, Grade = 5},
                new Review {Reviewer = 1, Movie = 3, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            var actualResult = ratingService.GetNumberOfRatesByReviewer(1,5);
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult == 2, "Number of rating 5 (from Reviewer = 111) is NOT 2.");
        }

        [TestMethod]
        public void TestNumberOfReviews()
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 2},
                new Review {Reviewer = 1, Movie = 2, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);
            var actualResult = ratingService.GetNumberOfReviews(1);
            mock.Verify(m => m.GetAllReviews(), Times.Once);
            Assert.IsTrue(actualResult == 2, "Number of reviews is NOT 2.");
        }

        [TestMethod]
        public void TestAverageRateOfMovie()
        {
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 1, Movie = 1, Grade = 2},
                new Review {Reviewer = 1, Movie = 2, Grade = 5},
                new Review {Reviewer = 2, Movie = 1, Grade = 1},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            //Act
            var actualResult = ratingService.GetAverageRateOfMovie(1);

            //Assert
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult.Equals(1.5), "Average rate is not 1.5.");
        }

        [TestMethod]
        public void TestNumberOfRates()
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 111, Movie = 1, Grade = 2},
                new Review {Reviewer = 111, Movie = 2, Grade = 5},
                new Review {Reviewer = 111, Movie = 3, Grade = 5},
                new Review {Reviewer = 112, Movie = 1, Grade = 1},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            //Act
            var actualResult = ratingService.GetNumberOfRates(1, 1);

            //Assert
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            Assert.IsTrue(actualResult == 1, "Number of rating 1 (for Movie = 1) is NOT 1.");
        }

        [TestMethod]
        public void TestMoviesWithHighestNumberOfTopRates()
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 111, Movie = 1, Grade = 5},
                new Review {Reviewer = 111, Movie = 2, Grade = 4},
                new Review {Reviewer = 111, Movie = 3, Grade = 3},

                new Review {Reviewer = 112, Movie = 1, Grade = 5},
                new Review {Reviewer = 112, Movie = 2, Grade = 5},
                new Review {Reviewer = 112, Movie = 3, Grade = 5},

                new Review {Reviewer = 113, Movie = 1, Grade = 5},
                new Review {Reviewer = 113, Movie = 2, Grade = 4},
                new Review {Reviewer = 113, Movie = 3, Grade = 5},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);
            var ratingService = new RatingService(mock.Object);
            var actualResult = ratingService.GetMoviesWithHighestNumberOfTopRates();

            var expectedResult = new List<int>() { 1, 3, 2 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult), "Top 5 movies with highest number of rating 5 is not as expected.");
        }

        [TestMethod]
        public void TestMostProductiveReviewers()
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 111, Movie = 1, Grade = 1},
                new Review {Reviewer = 111, Movie = 2, Grade = 4},
                new Review {Reviewer = 111, Movie = 3, Grade = 3},

                new Review {Reviewer = 112, Movie = 1, Grade = 1},

                new Review {Reviewer = 113, Movie = 1, Grade = 4},
                new Review {Reviewer = 113, Movie = 2, Grade = 4},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            //Act
            var actualResult = ratingService.GetMostProductiveReviewers();

            //Assert
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            var expectedResult = new List<int>() { 111, 113, 112 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult), "The list of most productive reviewers is NOT { 111, 113, 112 }.");
        }

        [TestMethod]
        public void TestTopRatedMovies()
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 111, Movie = 1, Grade = 5},
                new Review {Reviewer = 111, Movie = 2, Grade = 2},
                new Review {Reviewer = 111, Movie = 3, Grade = 3},

                new Review {Reviewer = 112, Movie = 1, Grade = 4},
                new Review {Reviewer = 112, Movie = 2, Grade = 4},

                new Review {Reviewer = 113, Movie = 2, Grade = 4},
                new Review {Reviewer = 113, Movie = 3, Grade = 4},
                new Review {Reviewer = 113, Movie = 4, Grade = 1},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            //Act
            var actualResult = ratingService.GetTopRatedMovies(3);

            //Assert
            //mock.Verify(m => m.GetAllReviews(), Times.Exactly(9));
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            var expectedResult = new List<int>() { 1, 3, 2 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult), "The list of top 3 rated movies is NOT { 1, 3, 2 }.");
        }

        [TestMethod]
        public void TestTopMoviesByReviewer() // RADO DIFFERENT
        {
            //Arrange
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 111, Movie = 1, Grade = 4, Date = DateTime.Parse("2020-03-11")},
                new Review {Reviewer = 111, Movie = 2, Grade = 5, Date = DateTime.Parse("2002-03-12")},
                new Review {Reviewer = 111, Movie = 3, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 112, Movie = 1, Grade = 3, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 112, Movie = 2, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 113, Movie = 2, Grade = 5, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 113, Movie = 3, Grade = 3, Date = DateTime.Parse("2020-03-12")},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            //Act
            var actualResult = ratingService.GetTopMoviesByReviewer(reviewer: 111);

            //Assert
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            var expectedResult = new List<int>() { 2, 3, 1 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult), "The list of movies in order of rating (subsequently date) is NOT { 2, 3, 1 }.");

            //RADO DIFFERENT
            Assert.IsTrue(actualResult.ElementAt(0) == 2);
            Assert.IsTrue(actualResult.ElementAt(1) == 3);
            Assert.IsTrue(actualResult.ElementAt(2) == 1);
        }

        [TestMethod]
        public void TestReviewersByMovie()
        {
           
            Mock<IRatingRepository> mock = new Mock<IRatingRepository>();

            Review[] returnValue =
            {
                new Review {Reviewer = 111, Movie = 1, Grade = 4, Date = DateTime.Parse("2020-03-11")},
                new Review {Reviewer = 111, Movie = 2, Grade = 5, Date = DateTime.Parse("2002-03-12")},
                new Review {Reviewer = 111, Movie = 3, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 112, Movie = 1, Grade = 4, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 112, Movie = 2, Grade = 4, Date = DateTime.Parse("2020-03-12")},

                new Review {Reviewer = 113, Movie = 2, Grade = 5, Date = DateTime.Parse("2020-03-12")},
                new Review {Reviewer = 113, Movie = 3, Grade = 3, Date = DateTime.Parse("2020-03-12")},
            };

            mock.Setup(m => m.GetAllReviews()).Returns(() => returnValue);

            var ratingService = new RatingService(mock.Object);

            //Act
            var actualResult = ratingService.GetReviewersByMovie(movie: 1);

            //Assert
            mock.Verify(m => m.GetAllReviews(), Times.Once);

            var expectedResult = new List<int>() { 112, 111 };

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult), "The list of reviewers in order of rating (subsequently date) is NOT { 112, 111 }.");

        }
    }
}
