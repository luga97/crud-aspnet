using BrandsCrud.Data.Map;
using BrandsCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BrandsCrud.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) :
            base(options)
        {
        }

        public DbSet<BrandModel> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
