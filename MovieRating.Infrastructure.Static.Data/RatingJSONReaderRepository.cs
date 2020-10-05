using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MovieRating.Infrastructure.Static.Data
{
    public class RatingJSONReaderRepository : IRatingRepository
    {

        IEnumerable<Review> _reviews = new List<Review>();

        readonly string _path = "ratings.json";

        public RatingJSONReaderRepository()
        {
            GetReviewsFromFile(_path);
        }


        public IEnumerable<Review> GetAllReviews()
        {
            return _reviews;
        }


        public void GetReviewsFromFile(string _path)
        {
            using (StreamReader streamReader = File.OpenText(_path))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                reader.CloseInput = true;
                var serializer = new JsonSerializer();
                var reviews = new List<Review>();

                var reviewers = new Dictionary<int, Reviewer>();
                var movies = new Dictionary<int, Movie>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        JSONReview jsonReview = serializer.Deserialize<JSONReview>(reader);
                        Movie movie;
                        Reviewer reviewer;
                        Review r = new Review();

                        if (!movies.ContainsKey(jsonReview.Movie))
                        {
                            movie = new Movie() { Id = jsonReview.Movie };
                            movies.Add(movie.Id, movie);
                            r.Movie = movie;
                        }

                        else
                        {
                            movies.TryGetValue(jsonReview.Movie, out movie);
                            r.Movie = movie;
                        }

                        if (!reviewers.ContainsKey(jsonReview.Reviewer))
                        {
                            reviewer = new Reviewer() { Id = jsonReview.Reviewer };
                            reviewers.Add(reviewer.Id, reviewer);
                            r.Reviewer = reviewer;
                        }

                        else
                        {
                            reviewers.TryGetValue(jsonReview.Reviewer, out reviewer);
                            r.Reviewer = reviewer;
                        }

                        r.Date = jsonReview.Date;
                        r.Grade = jsonReview.Grade;
                        reviews.Add(r);
                    }

                }
                _reviews = reviews;
            }
        }

        
    }
}
