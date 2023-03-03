using Airbnb.Models;
using Airbnbfinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Airbnbfinal.Controllers
{
    public class HomeController : Controller
    {
        private Graduationproject1Context db;

        public HomeController(Graduationproject1Context db) 
        {
            this.db = db;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public IActionResult Index()
        {
            List<Hotel> H = db.Hotels.Include(a => a.Images).Include(a => a.Rooms).ToList();
            return View(H);
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