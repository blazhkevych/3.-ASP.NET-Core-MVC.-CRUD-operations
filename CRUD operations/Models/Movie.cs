namespace CRUD_operations.Models;

public class Movie
{
    // Declare an integer property for the Id
    // This will be used as the primary key in the database
    public int Id { get; set; }

    // Declare a string property for the Title
    public string Title { get; set; }

    // Declare a string property for the Director
    public string Director { get; set; }

    // Declare a string property for the Genre
    public string Genre { get; set; }

    // Declare an integer property for the ReleaseYear
    public int ReleaseYear { get; set; }

    // Declare a string property for the PosterUrl
    // This will be used to store the URL of the movie poster
    public string PosterUrl { get; set; }

    // Declare a string property for the Description
    public string Description { get; set; }
}