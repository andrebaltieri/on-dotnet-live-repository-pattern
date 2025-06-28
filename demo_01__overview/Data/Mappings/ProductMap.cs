using DataDriven.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataDriven.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasMaxLength(160)
            .HasColumnType("NVARCHAR");
    }
}