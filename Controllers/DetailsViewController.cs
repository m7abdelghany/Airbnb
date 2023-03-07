using Airbnb.Models;
using Airbnbfinal.Data;
using Airbnbfinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Airbnbfinal.Controllers
{
    public class DetailsViewController : Controller
    {
        private Graduationproject1Context db;
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext dbContext;

        public DetailsViewController(Graduationproject1Context db, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            this.db = db;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }


        public IActionResult Index(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var hotels = db.Hotels.Include(a => a.Images).Include(a => a.Facilities).Include(a=>a.Hotel_adminNavigation).Include(a=>a.Reviews).ThenInclude(a=>a.User).FirstOrDefault(a => a.ID == id);
                //var reviews = db.Reviews.FirstOrDefault(a => a.Hotel_Id == id);

                

                return View(hotels);
            }
        }

    }

    
}
