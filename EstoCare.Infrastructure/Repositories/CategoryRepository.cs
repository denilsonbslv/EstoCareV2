using EstoCare.Domain.Entities;
using EstoCare.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstoCare.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório responsável pela manipulação das categorias no banco de dados.
    /// </summary>
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EstocareDbContext _context;

        public CategoryRepository(EstocareDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adiciona uma nova categoria ao repositório.
        /// </summary>
        /// <param name="category">A categoria a ser adicionada.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task AddAsync(Category category)
        {
            // Adiciona a categoria no contexto do banco de dados
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(); // Salva as alterações no banco
        }

        /// <summary>
        /// Atualiza uma categoria existente no repositório.
        /// </summary>
        /// <param name="category">A categoria a ser atualizada.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task UpdateAsync(Category category)
        {
            // Atualiza a categoria no banco de dados
            _context.Categories.Update(category);
            await _context.SaveChangesAsync(); // Salva as alterações no banco
        }

        /// <summary>
        /// Marca uma categoria como excluída (exclusão lógica) no repositório.
        /// </summary>
        /// <param name="category">A categoria a ser marcada como excluída.</param>
        /// <returns>Task representando a operação assíncrona.</returns>
        public async Task DeleteAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            // Marca a categoria como deletada (exclusão lógica)
            category.Delete();
            await UpdateAsync(category); // Atualiza a categoria no banco após marcar como deletada
        }

        /// <summary>
        /// Retorna uma categoria pelo seu identificador.
        /// </summary>
        /// <param name="id">O identificador da categoria.</param>
        /// <returns>A categoria encontrada ou null se não for encontrada.</returns>
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <summary>
        /// Retorna todas as categorias do repositório.
        /// </summary>
        /// <returns>Uma lista de categorias.</returns>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                .ToListAsync(); // Retorna todas as categorias
        }
    }
}
