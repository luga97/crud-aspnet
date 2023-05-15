using BrandsCrud.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrandsCrud.Data.Map
{
    public class BrandMap : IEntityTypeConfiguration<BrandModel>
    {
        public void Configure(EntityTypeBuilder<BrandModel> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
