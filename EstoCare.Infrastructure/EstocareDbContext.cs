using EstoCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EstoCare.Infrastructure.Configurations;

namespace EstoCare.Infrastructure
{
    /// <summary>
    /// Contexto do banco de dados do Estocare, responsável pela interação com o banco.
    /// </summary>
    public class EstocareDbContext : DbContext
    {
        public EstocareDbContext(DbContextOptions<EstocareDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Conjunto de categorias.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Conjunto de produtos.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica as configurações das entidades
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
