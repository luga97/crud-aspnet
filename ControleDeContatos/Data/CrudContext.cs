using ControleDeContatos.Data.Map;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext> options) :
            base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
