using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_Assignment_1_.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
