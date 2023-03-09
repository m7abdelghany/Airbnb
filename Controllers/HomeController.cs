using Airbnb.Models;
using Airbnbfinal.Data;
using Airbnbfinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Airbnbfinal.Controllers
{
    public class HomeController : Controller
    {
        private Graduationproject1Context db;
        private UserManager<ApplicationUser> userManager;

        public HomeController(Graduationproject1Context db, UserManager<ApplicationUser> userManager) 
        {
            this.db = db;
            this.userManager = userManager;
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

        public IActionResult Search(string searching)
        {
            if (!string.IsNullOrEmpty(searching))
            {
                List<Hotel> H = db.Hotels.Include(a => a.City).Include(a => a.Images).Where(a => a.City.CityName == searching || a.Name == searching).ToList();

                return View(H);
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public IActionResult Create()
        {
            SelectList cities = new SelectList(db.Cities.ToList(), "CityId","CityName");
            ViewBag.city = cities;

            SelectList categ = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.category = categ;

            //ViewBag.fac = new SelectList(db.Facilities.ToList(), "FacilityId", "FacilityType");
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Hotel h /*,int[] FacilitiesToAdd*/)
        {
            SelectList cities = new SelectList(db.Cities.ToList(), "CityId", "CityName");
            ViewBag.city = cities;

            SelectList categ = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.category = categ;

            

            //if (ModelState.IsValid)
            //{
                db.Add(h);
                db.SaveChanges();
                return RedirectToAction("index");
           // }

           // return View(h);
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
        [Authorize]
        [HttpGet]
        public async Task< IActionResult> Messages()
        {
            var user = await userManager.GetUserAsync(User);

            var username =user.UserName;
            ViewBag.username=username;
            var userid = user.Id;
           string id = "1";
            AspNetUser Husers = db.AspNetUsers.Include(a=>a.MessageHotelmangers).FirstOrDefault(a=>a.Id==userid);
            AspNetUser Rusers = db.AspNetUsers.Include(a=>a.MessageUsers).First(a=>a.Id==userid);
            
            return View(Husers);
        }
        [Authorize]
        [HttpPost]
        public async Task <IActionResult> Messages(int ID,string Msg)
        {
            var user = await userManager.GetUserAsync(User);
            var username = user.UserName;
            ViewBag.username = username;
            var userid = user.Id;
            AspNetUser Husers = db.AspNetUsers.Include(a => a.MessageHotelmangers).FirstOrDefault(a => a.Id == userid);
            Message m = new Message() { UserId=userid,HotelmangerId=ID.ToString(),Message1=Msg};
            db.Messages.Add(m);
            db.SaveChanges();
            return View(Husers);
        }
    }
}