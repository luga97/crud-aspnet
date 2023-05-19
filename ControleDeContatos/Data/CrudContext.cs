using BrandsCrud.Data.Map;
using BrandsCrud.Models;
using ControleDeContatos.Models;
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
        public DbSet<ClientModel> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
