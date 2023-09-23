using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD_operations.Models;

namespace CRUD_operations.Controllers;

public class MoviesController : Controller
{
    private readonly MovieContext _context;
    private readonly IWebHostEnvironment _appEnvironment;

    public MoviesController(MovieContext context, IWebHostEnvironment appEnvironment)
    {
        _context = context;
        _appEnvironment = appEnvironment;
    }

    // GET: Movies
    public async Task<IActionResult> Index()
    {
        return _context.Movies != null
            ? View(await _context.Movies.ToListAsync())
            : Problem("Entity set 'MovieContext.Movies'  is null.");
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Movies == null) return NotFound();

        var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return NotFound();

        return View(movie);
    }

    // GET: Movies/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movies/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Title,Director,Genre,ReleaseYear,PosterUrl,Description")]
        Movie movie, IFormFile uploadedFile)
    {
        if (ModelState.IsValid)
        {
            var path = "\\img\\" + uploadedFile.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            movie.PosterUrl = path;
            _context.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    // GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Movies == null) return NotFound();

        var movie = await _context.Movies.FindAsync(id);
        if (movie == null) return NotFound();
        return View(movie);
    }

    // POST: Movies/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,Title,Director,Genre,ReleaseYear,PosterUrl,Description")]
        Movie movie, IFormFile uploadedFile)
    {
        if (id != movie.Id) return NotFound();

        #region Error checking (errors in cosole)

        // Error checking (errors in cosole)
        if (!ModelState.IsValid)
        {
            foreach (var modelState in ViewData.ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }

        #endregion

        IFormFile аFile = uploadedFile;

        if (ModelState.IsValid)
        {
            try
            {
                var path = "\\img\\" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                movie.PosterUrl = path;
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Movies == null) return NotFound();

        var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return NotFound();

        return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Movies == null) return Problem("Entity set 'MovieContext.Movies'  is null.");
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null) _context.Movies.Remove(movie);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int id)
    {
        return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}