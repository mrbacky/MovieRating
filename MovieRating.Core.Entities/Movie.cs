using System.Collections.Generic;

namespace MovieRating.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public int AvgRating { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}