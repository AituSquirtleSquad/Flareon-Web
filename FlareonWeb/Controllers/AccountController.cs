using FlareonWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        /*private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;*/
        private FlareonWebContext _context;

        public AccountController(FlareonWebContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterRole()
        {
            ViewBag.Name = new SelectList(_context.Roles.ToList(), "Name", "Name");
            ViewBag.UserName = new SelectList(_context.Users.ToList(), "UserName", "UserName");
            return View();
        }
    }
}
