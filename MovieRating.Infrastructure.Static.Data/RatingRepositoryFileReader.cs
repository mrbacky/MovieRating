using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using newtonsoft 

namespace ConsoleApp
{
    public class RatingRepositoryFileReader : IRatingRepository
    {
        private readonly string _path = "ratings.json";

        public RatingRepositoryFileReader()
        {
            GetReviewsFromFile(_path);
        }

        private IEnumerable<Review> _ratingCollection;

        public IEnumerable<Review> GetAll()
        {
            return _ratingCollection;
        }

        public void GetReviewsFromFile(string _path)
        {
            using (StreamReader streamReader = File.OpenText(_path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                var ratings = new List<BERating>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        BERating review = serializer.Deserialize<BERating>(reader);
                        ratings.Add(review);
                    }

                }
                _ratingCollection = ratings;
            }
        }
    }
}
}