using EstoCare.Domain.Entities;

namespace Estocare.Application.Interfaces
{
    /// <summary>
    /// Interface que define os métodos relacionados à manipulação de categorias.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Recupera todas as categorias cadastradas.
        /// </summary>
        /// <returns>Uma lista de categorias.</returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();

        /// <summary>
        /// Cria uma nova categoria no sistema.
        /// </summary>
        /// <param name="category">Objeto que representa a categoria a ser criada.</param>
        /// <returns>A categoria criada.</returns>
        Task<Category> CreateCategoryAsync(Category category);

        /// <summary>
        /// Atualiza uma categoria existente.
        /// </summary>
        /// <param name="id">ID da categoria a ser atualizada.</param>
        /// <param name="category">Objeto com os dados atualizados da categoria.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        Task UpdateCategoryAsync(int id, Category category);

        /// <summary>
        /// Exclui uma categoria do sistema.
        /// </summary>
        /// <param name="id">ID da categoria a ser excluída.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        Task DeleteCategoryAsync(int id);
    }
}
