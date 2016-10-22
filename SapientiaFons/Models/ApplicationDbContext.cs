using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;

namespace SapientiaFons.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Material> Materials { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Hypothesis> Hypotheses { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public string GetShortUrl()
        {
            var result = string.Empty;

            while (string.IsNullOrEmpty(result) || this.Subjects.Where(r => r.ShortUrl == result).Any())
            {
                var guid = Guid.NewGuid().ToString();

                result = guid.Split('-')[0].Substring(0, 7);
            }

            return result;
        }
    }
}