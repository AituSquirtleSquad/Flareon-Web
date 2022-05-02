using FlareonWeb.Data;
using FlareonWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Controllers
{
    public class CinemasController : Controller
    {
        private readonly FlareonWebContext _context;
        public CinemasController(FlareonWebContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> CinemaIndex()
        {
            var cinemas = await _context.Cinemas.ToListAsync();
            return View(cinemas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                _context.Cinemas.Add(cinema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CinemaIndex));
            }
            return View(cinema);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            var cinemaInDb = await _context.Cinemas.FirstOrDefaultAsync(t => t.CinemaId == id);

            if (cinemaInDb == null)
                return NotFound();

            return View(cinemaInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            _context.Cinemas.Update(cinema);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(CinemaIndex));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }

            var cinemaInDb = await _context.Cinemas.FirstOrDefaultAsync(t => t.CinemaId == id);

            if (cinemaInDb == null)
            {
                return NotFound();
            }

            _context.Cinemas.Remove(cinemaInDb);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(CinemaIndex));
        }
    }
}
