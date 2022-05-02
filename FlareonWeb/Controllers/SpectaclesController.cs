using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlareonWeb.Controllers
{
    public class SpectaclesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
