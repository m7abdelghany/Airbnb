using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Airbnbfinal.Data
{
    public class ApplicationUser : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int? Age { get; set; }
        [StringLength(14)]
        public string NationalId { get; set; }
        
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}