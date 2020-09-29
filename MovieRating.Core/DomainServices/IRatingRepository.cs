﻿using MovieRating.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Core.DomainServices
{
    public interface IRatingRepository
    {

        IEnumerable<Review> GetAllReviews();

        IEnumerable<Movie> GetAllMovies();

        IEnumerable<Reviewer> GetAllReviewers();




    }
}
