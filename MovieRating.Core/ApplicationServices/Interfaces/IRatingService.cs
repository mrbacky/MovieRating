using System.Collections.Generic;

namespace MovieRating.Core
{
    public interface IRatingService
    {


        //  Rado
        public int GetNumberOfReviewsFromReviewer(int reviewer);

        //  Rado
        public int GetNumberOfReviews(int movie);

        //  Rado
        public List<int> GetMoviesWithHighestNumberOfTopRates();

        //  Rado
        public List<int> GetTopMoviesByReviewer(int reviewer);





        //  Martin
        public double GetAverageRateFromReviewer(int reviewer);

        //  Martin
        public double GetAverageRateOfMovie(int movie);

        //  Martin
        public List<int> GetMostProductiveReviewers();

        //  Martin
        public List<int> GetReviewersByMovie(int movie);






        //  Houmark
        public int GetNumberOfRates(int movie, int rate);

        //  Houmark
        public int GetNumberOfRatesByReviewer(int reviewer, int rate);

        //  Houmark
        public List<int> GetTopRatedMovies(int amount);




    }
}