using EstoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoCare.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tabela
            builder.ToTable("Categories");

            // Chave Primária
            builder.HasKey(c => c.Id);

            // Propriedades
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(c => c.UpdatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Exclusão Lógica
            builder.Property(c => c.IsDeleted)
                   .HasDefaultValue(false);

            // Relacionamento com Product
            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade); // Dependente da exclusão lógica

            builder.HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
