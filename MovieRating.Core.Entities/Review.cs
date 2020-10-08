using System;
using System.Collections.Generic;
using System.Dynamic;

namespace MovieRating.Core.Entities
{
    public class Review
    {
        public int Movie { get; set; }

        public int Reviewer { get; set; }

        public int Grade { get; set; }

        public DateTime Date { get; set; }

    }
}