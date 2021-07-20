using Domain.Entities.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace $safeprojectname$.DataAccess.DbContext.EntityConfigurations
{
    internal class OrdersEntityConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders", "dbo");

            builder.HasKey(e => new { e.Id }).HasName("Orders_PK");

            builder.Property(e => e.OrderId)
                .HasColumnName("OrderId")
                .HasMaxLength(100);

            builder.Property(e => e.ProductId)
                .HasColumnName("ProductId");

            builder.Property(e => e.ProductName)
                .HasColumnName("ProductName")
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Quantity)
                .HasColumnName("Quantity")
                .HasPrecision(2);

            builder.Property(e => e.Status).HasColumnType("Status");
        }
    }
}
