using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


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
            var allReviews = _ratingRepo.GetAllReviews().ToList();

            int topGrade = 0;
            foreach (var review in allReviews)
            {
                if (review.Grade >= topGrade)
                    topGrade = review.Grade;
            }

            var allMovies = new List<Movie>();
            foreach (var review in allReviews)
            {
                if (!allMovies.Contains(review.Movie))
                    allMovies.Add(review.Movie);
            }

            var d = new Dictionary<Movie, int>();

            foreach (var movie in allMovies)
            {
                d.Add(movie, allReviews.Count(r => r.Grade == topGrade));
            }

            var topList = new List<int>();


            var result = new List<int>();

            return result;
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
            int result = _ratingRepo.GetAllReviews().Count(r => r.Movie.Id == movie);
            return result;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int result = _ratingRepo.GetAllReviews().Count(r => r.Reviewer.Id == reviewer);
            return result;
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
