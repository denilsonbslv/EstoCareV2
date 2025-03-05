using System.Collections.Generic;
using System.Threading.Tasks;
using EstoCare.Domain.Entities;

namespace EstoCare.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Adiciona uma nova categoria ao repositório.
        /// </summary>
        /// <param name="category">A categoria a ser adicionada.</param>
        Task<Category> AddAsync(Category category);

        /// <summary>
        /// Atualiza uma categoria existente no repositório.
        /// </summary>
        /// <param name="category">A categoria a ser atualizada.</param>
        Task UpdateAsync(Category category);

        /// <summary>
        /// Marca uma categoria como excluída (exclusão lógica).
        /// </summary>
        /// <param name="category">A categoria a ser marcada como excluída.</param>
        Task DeleteAsync(Category category);

        /// <summary>
        /// Retorna uma categoria pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador da categoria.</param>
        Task<Category> GetByIdAsync(int id);

        /// <summary>
        /// Retorna todas as categorias.
        /// </summary>
        Task<IEnumerable<Category>> GetAllAsync();

        /// <summary>
        /// Retornar uma categoria pelo seu nome.
        /// </summary>
        Task<Category> GetByNameAsync(string name);
    }
}
