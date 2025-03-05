using EstoCare.Domain.Entities;

namespace EstoCare.Application.Interfaces
{
    /// <summary>
    /// Interface que define os métodos relacionados à manipulação de produtos.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Recupera todos os produtos cadastrados.
        /// </summary>
        /// <returns>Uma lista de produtos.</returns>
        Task<IEnumerable<Product>> GetProductsAsync();

        /// <summary>
        /// Recupera um produto específico pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto a ser recuperado.</param>
        /// <returns>O produto com o ID especificado.</returns>
        Task<Product> GetProductByIdAsync(int id);

        /// <summary>
        /// Cria um novo produto no sistema.
        /// </summary>
        /// <param name="product">Objeto que representa o produto a ser criado.</param>
        /// <returns>O produto criado.</returns>
        Task<Product> CreateProductAsync(Product product);

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="id">ID do produto a ser atualizado.</param>
        /// <param name="product">Objeto com os dados atualizados do produto.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        Task UpdateProductAsync(int id, Product product);

        /// <summary>
        /// Exclui um produto do sistema.
        /// </summary>
        /// <param name="id">ID do produto a ser excluído.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        Task DeleteProductAsync(int id);
    }
}
