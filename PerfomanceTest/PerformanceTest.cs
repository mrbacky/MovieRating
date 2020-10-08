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
        public void Function1()
        {
            RatingService test = new RatingService(_repo);

            test.GetNumberOfReviewsFromReviewer(1);

        }
    }
}
