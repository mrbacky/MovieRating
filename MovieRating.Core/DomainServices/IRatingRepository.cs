using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core.DomainServices
{
    public interface IRatingRepository
    {
        IEnumerable<Review> GetAllReviews();

<<<<<<< Updated upstream
=======
        IEnumerable<Movie> AllMovies();
>>>>>>> Stashed changes
    }
}
