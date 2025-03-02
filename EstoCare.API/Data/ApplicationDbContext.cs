using EstoCare.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace EstoCare.API.Data
{
    // Definindo o ApplicationDbContext, que herda de DbContext
    public class ApplicationDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração para o DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Definição das DbSets, representando as tabelas no banco de dados
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Product> Products { get; set; }

        // Aqui você pode configurar as tabelas e suas propriedades, se necessário
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da tabela Category
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");

                // Chave primária
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).ValueGeneratedOnAdd();

                // Configuração das propriedades
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.CreatedAt).IsRequired();
                entity.Property(c => c.UpdatedAt).IsRequired();
                entity.Property(c => c.IsDeleted).HasDefaultValue(false); // Excluindo logicamente

                // Relacionamento com produtos
                entity.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull); // Caso exclua categoria, não exclui o produto
            });

            // Configuração da tabela Subcategory
            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("Subcategories");

                // Chave primária
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).ValueGeneratedOnAdd();

                // Configuração das propriedades
                entity.Property(s => s.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(s => s.CreatedAt).IsRequired();
                entity.Property(s => s.UpdatedAt).IsRequired();
                entity.Property(s => s.IsDeleted).HasDefaultValue(false); // Excluindo logicamente

                // Relacionamento com produtos
                entity.HasMany(s => s.Products)
                    .WithOne(p => p.Subcategory)
                    .HasForeignKey(p => p.SubcategoryId)
                    .OnDelete(DeleteBehavior.SetNull); // Caso exclua subcategoria, não exclui o produto
            });

            // Configuração da tabela Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");

                // Chave primária
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();

                // Configuração das propriedades
                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(150);
                entity.Property(p => p.Description)
                    .HasMaxLength(500);
                entity.Property(p => p.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)"); // 18 dígitos no total, sendo 2 após a vírgula
                entity.Property(p => p.Stock)
                    .IsRequired();
                entity.Property(p => p.CreatedAt).IsRequired();
                entity.Property(p => p.UpdatedAt).IsRequired();
                entity.Property(p => p.IsDeleted).HasDefaultValue(false); // Excluindo logicamente

                // Relacionamento com Category
                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull); // Caso exclua categoria, não exclui o produto

                // Relacionamento com Subcategory
                entity.HasOne(p => p.Subcategory)
                    .WithMany(s => s.Products)
                    .HasForeignKey(p => p.SubcategoryId)
                    .OnDelete(DeleteBehavior.SetNull); // Caso exclua subcategoria, não exclui o produto
            });

            // Aplica o filtro de exclusão lógica globalmente
            modelBuilder.FilterDeleted();
        }
    }

    // Método de Extensão para Filtragem Global
    public static class ModelBuilderExtensions
    {
        public static void FilterDeleted(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Verifique se a entidade tem a propriedade 'IsDeleted'
                if (entity.ClrType.GetProperty("IsDeleted") != null)
                {
                    // Aplica o filtro global para o IsDeleted
                    modelBuilder.Entity(entity.ClrType)
                        .HasQueryFilter(GetIsDeletedExpression(entity.ClrType));
                }
            }
        }

        private static LambdaExpression GetIsDeletedExpression(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");
            var property = Expression.Property(parameter, "IsDeleted");
            var constant = Expression.Constant(false);
            var body = Expression.Equal(property, constant);
            var lambda = Expression.Lambda(body, parameter);
            return lambda;
        }
    }

}
