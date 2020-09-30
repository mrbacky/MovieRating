using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class RatingRepository : IRatingRepository
    {

        List<Review> allReviews = new List<Review>();

        public RatingRepository()
        {
            InitData();
        }

        private void InitData()
        {
            Reviewer re1 = new Reviewer { Id = 21 };
            Reviewer re2 = new Reviewer { Id = 22 };
            Reviewer re3 = new Reviewer { Id = 23 };
            Reviewer re4 = new Reviewer { Id = 24 };

            Movie m1 = new Movie { Id = 1 };
            Movie m2 = new Movie { Id = 2 };
            Movie m3 = new Movie { Id = 3 };

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m1, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m1, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m1, Reviewer = re4 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m2, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m2, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m2, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 1, Movie = m2, Reviewer = re4 });

            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 5, Movie = m3, Reviewer = re1 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m3, Reviewer = re2 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 4, Movie = m3, Reviewer = re3 });
            allReviews.Add(new Review() { Date = DateTime.Parse("2004-11-09"), Grade = 3, Movie = m3, Reviewer = re4 });

        }



        public IEnumerable<Review> GetAllReviews()
        {
            return allReviews;
        }
    }
}