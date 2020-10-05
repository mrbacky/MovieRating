using Microsoft.Extensions.DependencyInjection;
using MovieRating.Core;
using MovieRating.Core.DomainServices;
using MovieRating.Core.Entities;
using MovieRating.Infrastructure.Static.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IRatingService, RatingService>();
            serviceCollection.AddScoped<IRatingRepository, RatingJSONReaderRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var ratingService = serviceProvider.GetRequiredService<IRatingService>();
            var ratingRepo = serviceProvider.GetRequiredService<IRatingRepository>();




            var allReviews = ratingRepo.GetAllReviews().ToList();
            /*
            for (int i = 0; i < Math.Min(allReviews.Count(), 100); i++)
            {
                Review r = allReviews[i];
                Console.WriteLine($"Reviewer = {r.Reviewer.Id}, Movie = {r.Movie.Id}, Grade = {r.Grade}, Date = {r.Date}");
            }

           
            */
            Console.WriteLine("end");
        }
    }
}
