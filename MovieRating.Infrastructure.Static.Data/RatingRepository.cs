using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class RatingRepository : IRatingRepository
    {
        readonly List<Review> allReviews = new List<Review>();

        public RatingRepository()
        {
            InitDataFor_GetTopMoviesByReviewer();
            //InitDataFor_GetMoviesWithHighestNumberOfTopRates();
            // InitDataFor_GetNumberOfReviewsByReviewer();
        }

        private void InitDataFor_GetTopMoviesByReviewer()
        {

            var re1 = new Reviewer { Id = 21 };
            var re2 = new Reviewer { Id = 22 };
            var re3 = new Reviewer { Id = 23 };

            var m1 = new Movie { Id = 1 };
            var m2 = new Movie { Id = 2 };
            var m3 = new Movie { Id = 3 };
            var m4 = new Movie { Id = 4 };
            var m5 = new Movie { Id = 5 };
            var m6 = new Movie { Id = 6 };
            var m7 = new Movie { Id = 7 };

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m2, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m4, Reviewer = re3 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 5, Movie = m1, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-06"), Grade = 5, Movie = m2, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-13"), Grade = 4, Movie = m3, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-02"), Grade = 4, Movie = m4, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m5, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 3, Movie = m6, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-10"), Grade = 3, Movie = m7, Reviewer = re1 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 5, Movie = m1, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-09"), Grade = 4, Movie = m2, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-01"), Grade = 4, Movie = m3, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-05"), Grade = 1, Movie = m4, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-08"), Grade = 1, Movie = m5, Reviewer = re2 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-12"), Grade = 5, Movie = m1, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-11"), Grade = 4, Movie = m3, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-09-09"), Grade = 4, Movie = m5, Reviewer = re3 });


        }

        private void InitDataFor_GetMoviesWithHighestNumberOfTopRates()
        {
            Reviewer re1 = new Reviewer { Id = 21 };
            Reviewer re2 = new Reviewer { Id = 22 };
            Reviewer re3 = new Reviewer { Id = 23 };
            Reviewer re4 = new Reviewer { Id = 24 };

            Movie m1 = new Movie { Id = 10 };
            Movie m2 = new Movie { Id = 55 };
            Movie m3 = new Movie { Id = 2 };

            //                                                                  rating = 4
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-01"), Grade = 4, Movie = m1, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-02"), Grade = 4, Movie = m1, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-03"), Grade = 4, Movie = m1, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-04"), Grade = 1, Movie = m1, Reviewer = re4 });
            //                                                                  rating = 4.5
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-10"), Grade = 4, Movie = m2, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-11"), Grade = 4, Movie = m2, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-12"), Grade = 2, Movie = m2, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-29"), Grade = 2, Movie = m2, Reviewer = re4 });
            //                                                                  rating = 4.25
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-20"), Grade = 4, Movie = m3, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-21"), Grade = 4, Movie = m3, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-22"), Grade = 4, Movie = m3, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-23"), Grade = 1, Movie = m3, Reviewer = re4 });
        }

        private void InitDataFor_GetNumberOfReviewsByReviewer()
        {
            Reviewer re1 = new Reviewer { Id = 21 };
            Reviewer re2 = new Reviewer { Id = 22 };
            Reviewer re3 = new Reviewer { Id = 23 };

            Movie m1 = new Movie { Id = 1 };
            Movie m2 = new Movie { Id = 2 };
            Movie m3 = new Movie { Id = 3 };
            Movie m4 = new Movie { Id = 4 };
            Movie m5 = new Movie { Id = 5 };
            Movie m6 = new Movie { Id = 6 };
            Movie m7 = new Movie { Id = 7 };

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m2, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m3, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m4, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m5, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m6, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m7, Reviewer = re1 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m2, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m3, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 1, Movie = m4, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 1, Movie = m5, Reviewer = re2 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m2, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m3, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m4, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m5, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m6, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m7, Reviewer = re3 });

        }




        public IEnumerable<Review> GetAllReviews()
        {
            return allReviews;
        }
    }
}