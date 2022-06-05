
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SysVentas.Products.Infrastructure.Data.Base
{
    public static class PropertyTypeConfiguration
    {
        public static void CurrencyValue(this PropertyBuilder<decimal> property)
        {
            property.HasColumnType("decimal(17, 2)");
        }
    }
}
