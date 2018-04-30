namespace P04
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var movies = new Dictionary<string, TimeSpan>();
            var totalPlaylistDuration = new TimeSpan();

            string favouriteGenre = Console.ReadLine();
            string movieLength = Console.ReadLine();

            string line;
            while ((line = Console.ReadLine()) != "POPCORN!")
            {
                string[] movieInfo = line.Split('|');

                string movieName = movieInfo[0];
                string movieGenre = movieInfo[1];
                TimeSpan movieDuration = TimeSpan.Parse(movieInfo[2]);

                if (movieGenre == favouriteGenre)
                {
                    movies.Add(movieName, movieDuration);
                }
                totalPlaylistDuration += movieDuration;
            }

            if (movieLength == "Long")
            {
                foreach (var movie in movies.OrderByDescending(m => m.Value.Ticks).ThenBy(m => m.Key))
                {
                    Console.WriteLine(movie.Key);
                    string input = Console.ReadLine();

                    if (input == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");
                        break;
                    }
                }
            }
            else
            {
                foreach (var movie in movies.OrderBy(m => m.Value.Ticks).ThenBy(m => m.Key))
                {
                    Console.WriteLine(movie.Key);
                    string input = Console.ReadLine();

                    if (input == "Yes")
                    {
                        Console.WriteLine($"We're watching {movie.Key} - {movie.Value}");
                        Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");
                        break;
                    }
                }
            }
        }
    }
}
