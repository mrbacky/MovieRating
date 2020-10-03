using Microsoft.Extensions.DependencyInjection;
using MovieRating.Core;
using MovieRating.Core.DomainServices;
using System;
using System.ComponentModel;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IRatingService, RatingService>();
            serviceCollection.AddScoped<IRatingRepository, RatingRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var ratingService = serviceProvider.GetRequiredService<IRatingService>();
            

            var topList = ratingService.GetTopMoviesByReviewer(23);

            Console.WriteLine("END");
            
        }
    }
}
