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
            var s = _ratingRepo.GetAllReviews().Where(r => r.Reviewer == reviewer);
            double sum = 0;
            foreach (Review b in s)
            {
                sum += b.Grade;
            }
            return sum / s.Count();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            var s = _ratingRepo.GetAllReviews().Where(r => r.Movie == movie);
            double sum = 0;
            foreach (Review b in s)
            {
                sum += b.Grade;
            }
            return sum / s.Count();
        }

        public List<int> GetMostProductiveReviewers()
        {
            return _ratingRepo.GetAllReviews()
                .GroupBy(p => p.Reviewer)
                .OrderByDescending(p => p.Count())
                .Select(p => p.Key)
                .ToList();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            return _ratingRepo.GetAllReviews()
                .OrderByDescending(p => GetNumberOfRates(p.Movie, 5))
                .Select(p => p.Movie)
                .Distinct()
                .ToList();
        }

        public int GetNumberOfRates(int movie, int rate)
        {

            if (movie < 1)
                throw new ArgumentException("The id of the movie has to be larger than 0.");
            if (!(rate > 0 && rate < 6))
                throw new ArgumentException("The rate has to be within the range 1-5.");
            else
                return _ratingRepo.GetAllReviews().Count(p => p.Movie == movie && p.Grade == rate);

        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {

            return _ratingRepo.GetAllReviews().Count(p => p.Reviewer == reviewer && p.Grade == rate);

        }

        public int GetNumberOfReviews(int movie)
        {
            
          int result = _ratingRepo.GetAllReviews().Count(r => r.Movie == movie);
          return result;
        }

        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            int result = _ratingRepo.GetAllReviews().Count(r => r.Reviewer == reviewer);

            return result;
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            var list = _ratingRepo.GetAllReviews().Where(x => x.Movie == movie);

            var allReviewList = list.OrderByDescending(x => x.Grade).ThenByDescending(x => x.Date);

            List<int> reviewerlist = new List<int>();
            foreach (var v in allReviewList)
            {
                reviewerlist.Add(v.Movie);
            }
            return reviewerlist;
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            var allReviews = _ratingRepo.GetAllReviews().ToList();

            var reviewersReviews = allReviews.Where(r => r.Reviewer == reviewer)
                .OrderByDescending(r => r.Grade)
                .ThenByDescending(r => r.Date)
                .ThenBy(r => r.Movie);

            var idsList = new List<int>();

            foreach (var review in reviewersReviews)
                idsList.Add(review.Movie);

            return idsList;
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            return _ratingRepo.GetAllReviews()
                .OrderByDescending(p => GetAverageRateOfMovie(p.Movie))
                .Select(p => p.Movie)
                .Take(amount)
                .ToList();
        }
    }
}
