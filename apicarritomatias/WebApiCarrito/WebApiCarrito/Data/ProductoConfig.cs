using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiCarrito.Models;

namespace WebApiCarrito.Data
{
    public class ProductoConfig : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(p => p.IdMarcaNavigation)
                .WithMany(m => m.Productos)
                .HasForeignKey(p => p.IdMarca)
                .OnDelete(DeleteBehavior.Restrict);

       

            builder.HasOne(p => p.IdTalleNavigation)
                .WithMany(t => t.Productos)
                .HasForeignKey(p => p.IdTalle)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.IdColorNavigation)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdColor)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
