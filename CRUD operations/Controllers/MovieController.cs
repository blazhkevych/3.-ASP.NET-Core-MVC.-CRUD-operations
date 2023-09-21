using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CRUD_operations.Models;

namespace CRUD_operations.Controllers;

// Define a public class 'MovieController' that inherits from the 'Controller' base class
public class MovieController : Controller
{
    // Declare a private variable '_context' of type 'MovieContext'
    private MovieContext _context;

    // Define a public constructor for the 'MovieController' class that takes a 'MovieContext' object as a parameter
    public MovieController(MovieContext context)
    {
        // Assign the passed 'context' to the private '_context' variable
        _context = context;
    }

    // Define a public asynchronous method 'Index' that returns an 'IActionResult'
    public async Task<IActionResult> Index()
    {
        // Declare a variable 'movies' of type 'IEnumerable<Movie>' and assign it the result of a Task that returns all movies from the '_context'
        IEnumerable<Movie> movies = await Task.Run(() => _context.Movies);
        // Assign the 'movies' to the 'ViewBag.Movies' property
        ViewBag.Movies = movies;
        // Assign the string "Top 10 Films" to the 'ViewBag.Title' property
        ViewBag.Title = "Top 10 Films";
        // Return the view named "Index"
        return View("Index");
    }
}