using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core.DomainServices
{
    public interface IRatingRepository
    {

        IEnumerable<Review> GetAllReviews();

        //Dictionary<int, Reviewer> GetAllReviewers();

        //Dictionary<int, Movie> GetAllMovies();

        //Dictionary<int, JSONReview> GetAllJSONReviews();









    }
}
