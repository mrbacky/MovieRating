using System.Collections.Generic;

namespace MovieRating.Core.Entities
{
    public class Reviewer
    {
        public int Id { get; set; }

        public List<Review> Ratings { get; set; }


    }
}