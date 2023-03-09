using Airbnb.Models;
using Airbnbfinal.Data;
using Airbnbfinal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
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


        public  IActionResult Index(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var hotels = db.Hotels.Include(a => a.Images).Include(a => a.Facilities).Include(a => a.Hotel_adminNavigation).Include(a => a.Reviews).ThenInclude(a => a.User).FirstOrDefault(a => a.ID == id);
                //var reviews = db.Reviews.FirstOrDefault(a => a.Hotel_Id == id);



                return View(hotels);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task< IActionResult> addReview(int ID ,string rev)
        {
            
                var hotel = db.Hotels.Include(a => a.Images).Include(a => a.Facilities).Include(a => a.Hotel_adminNavigation).Include(a => a.Reviews).ThenInclude(a => a.User).FirstOrDefault(a => a.ID == ID);
            var user = await userManager.GetUserAsync(User);
            var userid = user.Id;
            
            var review = new Review { Hotel_Id = hotel.ID, User_Id = userid, Review1 = rev };
                db.Reviews.Add(review);
                db.SaveChanges();

            return View("index",hotel);




        }
      

        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> addReview([Bind("ReviewId,Review1,Hotel_Id,User_Id")] Review review)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Add(review);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Hotel_Id"] = new SelectList(db.Hotels, "ID", "ID", review.Hotel_Id);
        //    ViewData["User_Id"] = new SelectList(db.AspNetUsers, "Id", "Id", review.User_Id);
        //    return View(review);
        //}

    }

 
}
