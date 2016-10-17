using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace SapientiaFons.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Material> Materials { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Activity> Activities { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}