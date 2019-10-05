
using Microsoft.EntityFrameworkCore;
using apiAng.Api.Model;
namespace apiAng.Api.Data
{
    public class DataApiContext : DbContext
    {
        public DataApiContext(DbContextOptions<DataApiContext> options) : base(options)
        {

        }

        //public DbSet<Valuse> Valuse { get; set; }

        public DbSet<User> Users { get; set; }
    }
}