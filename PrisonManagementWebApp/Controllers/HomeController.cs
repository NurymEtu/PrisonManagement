using Microsoft.AspNetCore.Mvc;
using PrisonManagementWebApp.Data;
using PrisonManagementWebApp.Models;
using PrisonManagementWebApp.Tools;
using System.Diagnostics;

namespace PrisonManagementWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
        //    DataSeed.Seed(_context);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}