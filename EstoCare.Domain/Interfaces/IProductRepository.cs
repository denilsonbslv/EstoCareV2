using System.Collections.Generic;
using System.Threading.Tasks;
using EstoCare.Domain.Entities;

namespace EstoCare.Domain.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Adiciona um novo produto ao repositório.
        /// </summary>
        /// <param name="product">O produto a ser adicionado.</param>
        Task<Product> AddAsync(Product product);

        /// <summary>
        /// Atualiza um produto existente no repositório.
        /// </summary>
        /// <param name="product">O produto a ser atualizado.</param>
        Task UpdateAsync(Product product);

        /// <summary>
        /// Marca um produto como excluído (exclusão lógica).
        /// </summary>
        /// <param name="product">O produto a ser marcado como excluído.</param>
        Task DeleteAsync(Product product);

        /// <summary>
        /// Retorna um produto pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador do produto.</param>
        Task<Product> GetByIdAsync(int id);

        /// <summary>
        /// Retorna todos os produtos de uma categoria específica.
        /// </summary>
        /// <param name="categoryId">O identificador da categoria.</param>
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);

        /// <summary>
        /// Retorna todos os produtos.
        /// </summary>
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
