using Microsoft.EntityFrameworkCore;
using Producer.Models;

namespace Producer
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        }

        public DbSet<Product> products { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
