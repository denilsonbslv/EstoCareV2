using EstoCare.Domain.Entities;
using EstoCare.Application.Interfaces;
using EstoCare.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EstoCare.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de manipulação de produtos.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Injeção de dependência do repositório de produto.
        /// </summary>
        /// <param name="productRepository">Repositório de produtos a ser utilizado.</param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Recupera todos os produtos cadastrados.
        /// </summary>
        /// <returns>Uma lista de produtos.</returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        /// <summary>
        /// Recupera um produto específico pelo seu ID.
        /// </summary>
        /// <param name="id">ID do produto a ser recuperado.</param>
        /// <returns>O produto com o ID especificado.</returns>
        /// <exception cref="KeyNotFoundException">Lançado quando o produto não for encontrado.</exception>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
            }

            return product;
        }

        /// <summary>
        /// Cria um novo produto no sistema.
        /// </summary>
        /// <param name="product">Objeto que representa o produto a ser criado.</param>
        /// <returns>O produto criado.</returns>
        public async Task<Product> CreateProductAsync(Product product)
        {
            // Podemos adicionar regras de negócio aqui antes de salvar o produto, se necessário
            return await _productRepository.AddAsync(product);
        }

        /// <summary>
        /// Atualiza um produto existente.
        /// </summary>
        /// <param name="id">ID do produto a ser atualizado.</param>
        /// <param name="product">Objeto com os dados atualizados do produto.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        /// <exception cref="KeyNotFoundException">Lançado quando o produto não for encontrado.</exception>
        public async Task UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
            }

            // Atualizar as propriedades do produto
            existingProduct.UpdateName(product.Name);
            existingProduct.UpdatePrice(product.Price); // Exemplo de outra propriedade do produto

            await _productRepository.UpdateAsync(existingProduct);
        }

        /// <summary>
        /// Exclui um produto do sistema.
        /// </summary>
        /// <param name="id">ID do produto a ser excluído.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        /// <exception cref="KeyNotFoundException">Lançado quando o produto não for encontrado.</exception>
        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
            }

            // Marcar o produto como deletado, sem removê-lo fisicamente
            product.Delete();

            await _productRepository.UpdateAsync(product);
        }
    }
}
