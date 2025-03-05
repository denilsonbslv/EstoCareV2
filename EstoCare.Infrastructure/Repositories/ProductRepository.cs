using EstoCare.Domain.Entities;
using EstoCare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstoCare.Infrastructure.Repositories
{
    /// <summary>
    /// Implementação do repositório para a entidade Product.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly EstocareDbContext _context;

        public ProductRepository(EstocareDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona um novo produto ao banco de dados.
        /// </summary>
        /// <param name="product">Produto a ser adicionado.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza um produto existente no banco de dados.
        /// </summary>
        /// <param name="product">Produto a ser atualizado.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Marca um produto como excluído logicamente.
        /// </summary>
        /// <param name="product">Produto a ser excluído logicamente.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task DeleteAsync(Product product)
        {
            product.Delete(); // Utiliza o método de exclusão lógica na entidade Product.
            await UpdateAsync(product); // Atualiza o produto com a marcação de exclusão.
        }

        /// <summary>
        /// Recupera todos os produtos do banco de dados.
        /// </summary>
        /// <returns>Lista de produtos.</returns>
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category) // Inclui a categoria associada ao produto.
                .ToListAsync();
        }

        /// <summary>
        /// Recupera um produto específico pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <returns>Produto encontrado ou null.</returns>
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category) // Inclui a categoria associada ao produto.
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Obtém todos os produtos associados a uma categoria específica.
        /// </summary>
        /// <param name="categoryId">O identificador da categoria para a qual os produtos serão filtrados.</param>
        /// <returns>Uma lista assíncrona de produtos pertencentes à categoria especificada.</returns>
        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            // Filtra os produtos que possuem o CategoryId correspondente ao id fornecido
            return await _context.Products
                .Where(p => p.CategoryId == categoryId) // Filtra os produtos pela categoria
                .Include(p => p.Category) // Inclui a categoria associada ao produto para garantir que as informações da categoria sejam carregadas
                .ToListAsync(); // Retorna a lista de produtos encontrados de forma assíncrona
        }

    }
}
