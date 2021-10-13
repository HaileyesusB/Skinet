using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(P => P.ID).IsRequired();
            builder.Property(P => P.Name).IsRequired().HasMaxLength(100);
            builder.Property(P => P.Price).HasColumnType("decimal(18,2)");
            builder.Property(P => P.Descriprtion).IsRequired();
            builder.Property(P => P.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany()
                .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany()
                 .HasForeignKey(t => t.ProductTypeId);
        }
    }
}
