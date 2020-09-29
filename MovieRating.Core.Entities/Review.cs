using System;
using System.Collections.Generic;
using System.Dynamic;

namespace MovieRating.Core.Entities
{
    public class Review
    {
        public Movie Movie { get; set; }

        public Reviewer Reviewer { get; set; }

        public int Grade { get; set; }

        public DateTime Date { get; set; }

    }
}