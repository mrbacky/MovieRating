﻿using System.Collections.Generic;

namespace MovieRating.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public double Rating { get; set; }

        public List<Review> Reviews { get; set; }
    }
}