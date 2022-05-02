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
    public class TheatersController : Controller
    {

        private readonly FlareonWebContext _context;
        public TheatersController(FlareonWebContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> TheaterIndex()
        {
            var theaters = await _context.Theaters.ToListAsync();
            return View(theaters);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Theater theater)
        {
            if(ModelState.IsValid)
            {
                _context.Theaters.Add(theater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TheaterIndex));
            }
            return View(theater);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || id <= 0)
            {
                return BadRequest();
            }

            var theaterInDb = await _context.Theaters.FirstOrDefaultAsync(t => t.TheaterId == id);

            if (theaterInDb == null)
                return NotFound();

            return View(theaterInDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Theater theater)
        {
            if(!ModelState.IsValid)
            {
                return View(theater);
            }

            _context.Theaters.Update(theater);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(TheaterIndex));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || id <= 0)
            {
                return BadRequest();
            }

            var theaterInDb = await _context.Theaters.FirstOrDefaultAsync(t => t.TheaterId == id);

            if(theaterInDb == null)
            {
                return NotFound();
            }

            _context.Theaters.Remove(theaterInDb);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(TheaterIndex));
        }
    }
}
