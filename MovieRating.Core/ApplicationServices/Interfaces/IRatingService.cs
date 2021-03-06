﻿using System.Collections.Generic;

namespace MovieRating.Core
{
    public interface IRatingService
    {

        //  Rado
        public int GetNumberOfReviewsFromReviewer(int reviewer);

        //  Rado
        public int GetNumberOfReviews(int movie);

        //  Rado
        //  Parameter needed or determining if the user wants top x movies with highest number of top grade
        //  for now it is top 2 movies
        public List<int> GetMoviesWithHighestNumberOfTopRates();

        /*  Rado
         *  Reviewer can rate more movies with the same grade on the same day, so we have to sort reviews 
         *  not only by rate and date but by something specific  
         */

        
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