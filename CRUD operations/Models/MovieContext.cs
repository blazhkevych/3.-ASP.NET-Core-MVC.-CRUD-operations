using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_operations.Models;

// Creating a class that inherits from DbContext to interact with the database
public class MovieContext : DbContext
{
    // Defining a DbSet property for the Movie model
    public DbSet<Movie> Movies { get; set; }

    // Constructor for the MovieContext class
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
        // Checking if the database is created, if not it will be created
        if (Database.EnsureCreated())
        {
            // Adding movie data to the Movies DbSet
            // 1. Adding "The Shawshank Redemption" movie data
            Movies.Add(new Movie
            {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Genre = "Drama",
                ReleaseYear = 1994,
                PosterUrl = "\\img\\The_Shawshank_Redemption_1994.jpg",
                Description =
                    "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion."
            });
            // 2. Adding "The Godfather" movie data
            Movies.Add(new Movie
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Genre = "Crime",
                ReleaseYear = 1972,
                PosterUrl = "\\img\\The_Godfather_(1972).jpg",
                Description =
                    "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger."
            });
            // 3. Adding "The Dark Knight" movie data
            Movies.Add(new Movie
            {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Genre = "Action",
                ReleaseYear = 2008,
                PosterUrl = "\\img\\The_Dark_Knight_(2008).jpg",
                Description =
                    "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
            });
            // 4. Adding "The Godfather: Part II" movie data
            Movies.Add(new Movie
            {
                Title = "The Godfather: Part II",
                Director = "Francis Ford Coppola",
                Genre = "Crime",
                ReleaseYear = 1974,
                PosterUrl = "\\img\\The_Godfather_Part_II_(1974).jpg",
                Description =
                    "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate."
            });
            // 5. Adding "12 Angry Men" movie data
            Movies.Add(new Movie
            {
                Title = "12 Angry Men",
                Director = "Sidney Lumet",
                Genre = "Drama",
                ReleaseYear = 1957,
                PosterUrl = "\\img\\12_Angry_Men_(1957).jpg",
                Description =
                    "A jury holdout attempts to prevent a miscarriage of justice by forcing his colleagues to reconsider the evidence."
            });
            // 6. Adding "Schindler's List" movie data
            Movies.Add(new Movie
            {
                Title = "Schindler's List",
                Director = "Steven Spielberg",
                Genre = "Drama",
                ReleaseYear = 1993,
                PosterUrl = "\\img\\Schindler's_List_(1993).jpg",
                Description =
                    "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis."
            });
            // 7. Adding "The Lord of the Rings: The Return of the King" movie data
            Movies.Add(new Movie
            {
                Title = "The Lord of the Rings: The Return of the King",
                Director = "Peter Jackson",
                Genre = "Adventure",
                ReleaseYear = 2003,
                PosterUrl = "\\img\\The_Lord_of_the_Rings_The_Return_of_the_King_(2003).jpg",
                Description =
                    "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring."
            });
            // 8. Adding "Pulp Fiction" movie data
            Movies.Add(new Movie
            {
                Title = "Pulp Fiction",
                Director = "Quentin Tarantino",
                Genre = "Crime",
                ReleaseYear = 1994,
                PosterUrl = "\\img\\Pulp_Fiction_(1994).jpg",
                Description =
                    "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption."
            });
            // 9. Adding "The Lord of the Rings: The Fellowship of the Ring" movie data
            Movies.Add(new Movie
            {
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Director = "Peter Jackson",
                Genre = "Adventure",
                ReleaseYear = 2001,
                PosterUrl = "\\img\\The_Lord_of_the_Rings_The_Fellowship_of_the_Ring_(2001).jpg",
                Description =
                    "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron."
            });
            // 10. Adding "Il buono, il brutto, il cattivo" movie data
            Movies.Add(new Movie
            {
                Title = "Il buono, il brutto, il cattivo",
                Director = "Sergio Leone",
                Genre = "Western",
                ReleaseYear = 1966,
                PosterUrl = "\\img\\The_Good_the_Bad_and_the_Ugly_1966.jpg",
                Description =
                    "A bounty hunting scam joins two men in an uneasy alliance against a third in a race to find a fortune in gold buried in a remote cemetery."
            });
            // Saving the changes to the database
            SaveChanges();
        }
    }
}