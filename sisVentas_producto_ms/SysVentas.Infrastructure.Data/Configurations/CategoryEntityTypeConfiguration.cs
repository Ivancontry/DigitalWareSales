using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysVentas.Domain.Entities.Categorys;
namespace SysVentas.Infrastructure.Data.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category),ProductDataContext.DefaultSchema);
            builder.HasKey(t => t.Id);
        }
    }
}
