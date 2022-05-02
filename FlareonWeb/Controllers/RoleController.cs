using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FlareonWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace FlareonWeb.Controllers
{
    public class RoleController : Controller
    {
        FlareonWebContext _context;

        public RoleController(FlareonWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Roles = _context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _context.Roles.Add(Role);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
