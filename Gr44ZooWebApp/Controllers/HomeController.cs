using Gr44ZooWebApp.Models;
using Gr44ZooWebApp.Models.Repos;
using Gr44ZooWebApp.Models.Servises;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gr44ZooWebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly IAnimalsService _animalsService;
        public HomeController(IAnimalsService animalsService)
        {
            _animalsService = animalsService;
        }

        public IActionResult Index()
        {
            return View(_animalsService.LastAdded());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}