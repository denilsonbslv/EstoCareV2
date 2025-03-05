using EstoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoCare.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            // Configuração das propriedades de Product
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            // Relacionamento com Category
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevenindo a exclusão em cascata (pois usamos exclusão lógica)

            // Garantir que o nome do produto seja único
            builder.HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
