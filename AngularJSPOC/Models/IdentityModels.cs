using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AngularJSPOC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Test> Test { get; set; }
        public DbSet<Employee> Emp { get; set; }
    }
}