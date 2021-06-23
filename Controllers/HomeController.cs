using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_MVC.Models;
using Microsoft.AspNetCore.Http;

namespace E_Players_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Usuario = HttpContext.Session.GetString("Usuario");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
