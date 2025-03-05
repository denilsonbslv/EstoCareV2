using EstoCare.Domain.Entities;

namespace EstoCare.Application.Interfaces
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
        /// Recupera uma categoria específica pelo seu ID.
        /// </summary>
        /// <returns>A categoria com o ID especificado.</returns>
        Task<Category> GetCategoryByIdAsync(int id);

        /// <summary>
        /// Recupera uma Categoria específica pelo seu nome.
        /// </summary>
        /// <returns>A categoria com o nome especificado.</returns>
        Task<Category> GetCategoryByNameAsync(string name);

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
