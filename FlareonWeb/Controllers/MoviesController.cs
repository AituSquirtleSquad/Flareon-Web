using FlareonWeb.Data;
using FlareonWeb.Models;
using FlareonWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Controllers
{
    public class MoviesController : Controller
    {
        private readonly FlareonWebContext _context;
        public MoviesController(FlareonWebContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> MovieIndex()
        {
            var movies = await _context.Movies.ToListAsync();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            var vm = new MovieViewModel();
            vm.Cinemas = _context.Cinemas.ToList();


            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MovieIndex));
            }
            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            var movieInDb = await _context.Movies.FirstOrDefaultAsync(t => t.MovieId == id);

            if (movieInDb == null)
                return NotFound();

            return View(movieInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return View(movie);
            }

            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MovieIndex));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            var movieInDb = await _context.Movies.FirstOrDefaultAsync(t => t.MovieId == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(MovieIndex));
        }
    }
}
