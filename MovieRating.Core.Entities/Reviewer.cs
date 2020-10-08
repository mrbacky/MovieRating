using System.Collections.Generic;

namespace MovieRating.Core.Entities
{
    public class Reviewer
    {
        public class BEReviewer
        {
            public int Id;
            public List<Review> _ratingRepo;
        }
    }
}