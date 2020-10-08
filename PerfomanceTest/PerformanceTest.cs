using ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieRating.Core;
using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;

namespace PerfomanceTest
{
    [TestClass]
    public class PerformanceTest
    {
        private static IRatingRepository _repo;

        [ClassInitialize]
        public static void SetupRepo(TestContext tc)
        {
            _repo = new RatingRepositoryFileReader();
        }

        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfReviewsFromReviewer()
        {
            RatingService service = new RatingService(_repo);

            service.GetNumberOfReviewsFromReviewer(1);

        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetAverageFromReviewer()
        {
            RatingService service = new RatingService(_repo);

            service.GetAverageRateFromReviewer(1);

        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetAverageRateOfMovie()
        {
            RatingService service = new RatingService(_repo);

            service.GetAverageRateOfMovie(1);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetMostProductiveReviewer()
        {
            RatingService service = new RatingService(_repo);

            service.GetMostProductiveReviewers();

        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetMoviesWithHighestNumberOfTopRate()
        {
            RatingService service = new RatingService(_repo);

            service.GetMoviesWithHighestNumberOfTopRates();

        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfRates()
        {
            RatingService service = new RatingService(_repo);

            service.GetNumberOfRates(1,1);

        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfRatesByReviewer()
        {
            RatingService service = new RatingService(_repo);

            service.GetNumberOfRatesByReviewer(1,1);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetNumberOfReviews()
        {
            RatingService service = new RatingService(_repo);

            service.GetNumberOfReviews(1);

        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetReviewsByMovie()
        {
            RatingService service = new RatingService(_repo);

            service.GetReviewersByMovie(1);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetTopMoviesByReviewer()
        {
            RatingService service = new RatingService(_repo);

            service.GetTopMoviesByReviewer(1);
        }
        [TestMethod]
        [Timeout(4000)]
        public void TestGetTopRatedMovies()
        {
            RatingService service = new RatingService(_repo);

            service.GetTopRatedMovies(3);
        }
    }
}
