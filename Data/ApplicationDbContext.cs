using CrudTestMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudTestMVC.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option) { }
        public DbSet<Users> users { get; set; }
    }
}
