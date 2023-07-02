using MovieStore.Models;

namespace MovieStore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context?.Database.EnsureCreated();


                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(
                        new List<Movie>()
                        {
                            new Movie()
                            {
                                Name = "The Godfather",
                                Description = "This is the Godfather movie description",
                                Price = 39.50,
                                ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/3Tf8vXykYhzHdT0BtsYTp570JGQ.jpg",
                                ReleaseDate = 1972,
                                
                            },
                            new Movie()
                            {
                                Name = "The Godfather Part II",
                                Description = "This is the Godfather Part II movie description",
                                Price = 33.50,
                                ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/5ZSfJ9aleg2rGhVWp0Dcqv38Nr5.jpg",
                                ReleaseDate = 1974,
                                
                            },
                            new Movie()
                            {
                                Name = "The Shawshank Redemption",
                                Description = "This is The Shawshank Redemption movie description",
                                Price = 30.00,
                                ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/lyQBXzOQSuE59IsHyhrp0qIiPAz.jpg",
                                ReleaseDate = 1994,
                               
                            },
                            new Movie()
                            {
                                Name = "John Wick: Chapter 4",
                                Description = "This is the John Wick: Chapter 4 movie description",
                                Price = 31.00,
                                ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/vZloFAK7NmvMGKE7VkF5UHaz0I.jpg",
                                ReleaseDate = 2023,
                               
                            },
                            new Movie()
                            {
                                Name = "Se7en",
                                Description = "This is the Se7en movie description",
                                Price = 31.00,
                                ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/6yoghtyTpznpBik8EngEmJskVUO.jpg",
                                ReleaseDate = 1995,
                               
                            },
                           new Movie()
                            {
                                Name = "Scarface",
                                Description = "This is the Scarface movie description",
                                Price = 28.00,
                                ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/lqwY8LcEpThlYTWOjwDbUxVXZEa.jpg",
                                ReleaseDate = 1983,
                               
                            },
                           new Movie()
                            {
                                Name = "GoodFellas",
                                Description = "This is the GoodFellas movie description",
                                Price = 28.00,
                                ImageURL = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/aKuFiU82s5ISJpGZp7YkIr3kCUd.jpg",
                                ReleaseDate = 1990,
                               
                            },
                        }
                    );
                    context.SaveChanges();
                }

                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Marlon Brando",
                            Biography = "This is the Bio of Marlon Brando",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/fuTEPMsBtV1zE98ujPONbKiYDc2.jpg"

                        },
                        new Actor()
                        {
                            FullName = "Al Pacino",
                            Biography = "This is the Bio of Al Pacino",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/fMDFeVf0pjopTJbyRSLFwNDm8Wr.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Robert De Niro",
                            Biography = "This is the Bio of Robert De Niro",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/cT8htcckIuyI1Lqwt1CvD02ynTh.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Morgan Freeman",
                            Biography = "This is the Bio of Morgan Freeman",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/jPsLqiYGSofU4s6BjrxnefMfabb.jpg"
                        },
                        new Actor()
                        {
                            FullName = "Keanu Reeves",
                            Biography = "This is the Bio of Keanu Reeves",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/4D0PpNI0kmP58hgrwGC3wCjxhnm.jpg"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Directors.Any())
                {
                    context.Directors.AddRange(new List<Director>()
                    {
                        new Director()
                        {
                            FullName = "Francis Ford Coppola",
                            Biography = "This is the Bio of Francis Ford Coppola",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/3Pblihd6KjXliie9vj4iQJwbNPU.jpg"

                        },
                        new Director()
                        {
                            FullName = "Frank Darabont",
                            Biography = "This is the Bio of Frank Darabont",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/nvOqAQhKtXdHtczgqanoCfltsxJ.jpg"
                        },
                        new Director()
                        {
                            FullName = "Chad Stahelski",
                            Biography = "This is the Bio of Chad Stahelski",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/eRCryGwKDH4XqUlrdkERmeBWPo8.jpg"
                        },
                        new Director()
                        {
                            FullName = "David Fincher",
                            Biography = "This is the Bio of David Fincher",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/tpEczFclQZeKAiCeKZZ0adRvtfz.jpg"
                        },
                        new Director()
                        {
                            FullName = "Brian De Palma",
                            Biography = "This is the Bio of Brian De Palma",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/4xleWFdhtVC7faer6Ru2eyEgfTv.jpg"
                        }
                        ,
                        new Director()
                        {
                            FullName = "Martin Scorsese",
                            Biography = "This is the Bio of Martin Scorsese",
                            ProfilePictureURL = "https://www.themoviedb.org/t/p/w300_and_h450_bestv2/9U9Y5GQuWX3EZy39B8nkk4NY01S.jpg"
                        },
                    });
                    context.SaveChanges();
                }






            }
        }
    }
}
