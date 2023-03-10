using Airbnb.Models;
using Airbnbfinal.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnbfinal.Controllers
{
    public class AdminDashBoard : Controller
    {
        private Graduationproject1Context db;
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
       

        public AdminDashBoard(Graduationproject1Context db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            
        }
        public async Task<IActionResult> Index()
        {
            //var users = userManager.Users.ToList();
            //string u = "";
            //foreach (var item in users)
            //{
            //    u += item.UserName + ", ";
            //    var roles = await userManager.GetRolesAsync(item);
            //    foreach (var role in roles)
            //    {
            //        u += role;
            //    }
            //    u+= "\n";

            //}
            var users = db.AspNetUsers.ToList();
           
            return View(users);
        }
    }
}
