using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            var s = _ratingRepo.GetAllReviews().Where(r => r.Reviewer.Id == reviewer);
            double sum = 0;
            foreach (Review b in s)
            {
                sum += b.Grade;
            }
            return sum / s.Count();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            var s = _ratingRepo.GetAllReviews().Where(r => r.Movie.Id == movie);
            double sum = 0;
            foreach (Review b in s)
            {
                sum += b.Grade;
            }
            return sum / s.Count();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            var allReviews = _ratingRepo.GetAllReviews().ToList();
            int topGrade = 0;
            //  looking up the top grade
            foreach (var review in allReviews)
                if (review.Grade > topGrade)
                    topGrade = review.Grade;

            var allMovies = new List<Movie>();
            //  populating list with movies
            foreach (var review in allReviews)
                if (!allMovies.Contains(review.Movie))
                    allMovies.Add(review.Movie);
            foreach (var movie in allMovies)
                movie.TopGradeCount = allReviews.Where(r => r.Grade == topGrade && r.Movie == movie).Count();

            var top2Movies = allMovies.OrderByDescending(m => m.TopGradeCount).ThenBy(m => m.Id).ToList().GetRange(0, 2);

            var idsOfTopMovies = new List<int>();


            foreach (var m in top2Movies)
                idsOfTopMovies.Add(m.Id);


            return idsOfTopMovies;

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
            var allReviews = _ratingRepo.GetAllReviews().ToList();

            var reviewersReviews = allReviews.Where(r => r.Reviewer.Id == reviewer)
                .OrderByDescending(r => r.Grade)
                .ThenByDescending(r => r.Date)
                .ThenBy(r => r.Movie.Id);

            var idsList = new List<int>();

            foreach (var review in reviewersReviews)
                idsList.Add(review.Movie.Id);

            return idsList;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
