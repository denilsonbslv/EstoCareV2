using EstoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstoCare.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Definição da tabela
            builder.ToTable("Categories");

            // Definição da chave primária
            builder.HasKey(c => c.Id);

            // Configuração do campo Name
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Configuração dos timestamps
            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()"); // Define a data de criação automaticamente

            builder.Property(c => c.UpdatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()"); // Define a data de atualização automaticamente

            // Configuração da exclusão lógica
            builder.Property(c => c.IsDeleted)
                   .IsRequired()
                   .HasDefaultValue(false);

            // Aplica um filtro global para ignorar registros deletados
            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
