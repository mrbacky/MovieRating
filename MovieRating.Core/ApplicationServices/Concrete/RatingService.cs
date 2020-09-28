using MovieRating.Core.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core
{
    public class RatingService : IRatingService
    {
        readonly IRatingRepository _ratingRepo;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepo = ratingRepository;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _ratingRepo.GetNumberOfReviewsFromReviewer(reviewer);
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
