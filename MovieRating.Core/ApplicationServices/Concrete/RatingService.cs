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
            //  looking up the top grade
            foreach (var review in allReviews)
                if (review.Grade >= topGrade)
                    topGrade = review.Grade;

            var allMovies = new List<Movie>();
            //  populating list with movies
            foreach (var review in allReviews)
                if (!allMovies.Contains(review.Movie))
                    allMovies.Add(review.Movie);

            var dict = new Dictionary<Movie, int>();
            //  looking up number of top grades for each movie from reviews
            foreach (var movie in allMovies)
                if (!dict.ContainsKey(movie))
                    dict.Add(movie, allReviews.Where(r => r.Grade == topGrade && r.Movie == movie).Count());

            var d = dict.ToList();

            //  sorting movies by number of top grades DESC
            d.Sort((a, b) => b.Value.CompareTo(a.Value));

            //  there is no other parameter to decide which movie will be the last one 
            //  in top 2 movies list when the 3rd movie has the same number of top grades. (possible parameter: rating)
            var top2Movies = d.GetRange(0, 2);

            //  populating int list with movie id's
            var idsOfTopMovies = new List<int>();
            foreach (var item in top2Movies)
                idsOfTopMovies.Add(item.Key.Id);

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
            throw new NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
