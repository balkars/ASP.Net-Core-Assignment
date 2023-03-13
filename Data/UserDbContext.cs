using Microsoft.EntityFrameworkCore;
using CarSales.Core.Models;
namespace CarSales.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }

       
    }
}
