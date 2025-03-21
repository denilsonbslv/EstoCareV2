﻿using EstoCare.Application.Interfaces;
using EstoCare.Domain.Entities;
using EstoCare.Domain.Interfaces;

namespace EstoCare.Application.Services
{
    /// <summary>
    /// Implementação dos serviços de manipulação de categorias.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        /// <summary>
        /// Injeção de dependência do repositório de categoria.
        /// </summary>
        /// <param name="categoryRepository">Repositório de categorias a ser utilizado.</param>
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Recupera todas as categorias cadastradas.
        /// </summary>
        /// <returns>Uma lista de categorias.</returns>
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        /// <summary>
        /// Recupera uma categoria específica pelo seu ID.
        /// </summary>
        /// <returns>Retorna uma categoria especifica pelo seu ID</returns>
        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Recupera uma Categoria específica pelo seu nome.
        /// </summary>
        /// <returns>Retorna uma categoria especifica pelo seu nome</returns>
        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        /// <summary>
        /// Cria uma nova categoria no sistema.
        /// </summary>
        /// <param name="category">Objeto que representa a categoria a ser criada.</param>
        /// <returns>A categoria criada.</returns>
        /// <exception cref="InvalidOperationException">Lançado quando a categoria já existe.</exception>
        public async Task<Category> CreateCategoryAsync(Category category)
        {
            // Verificar se a categoria já existe
            var existingCategory = await _categoryRepository.GetByNameAsync(category.Name);
            if (existingCategory != null)
            {
                throw new InvalidOperationException("Categoria com esse nome já existe.");
            }

            // Criar a nova categoria
            return await _categoryRepository.AddAsync(category);
        }

        /// <summary>
        /// Atualiza uma categoria existente.
        /// </summary>
        /// <param name="id">ID da categoria a ser atualizada.</param>
        /// <param name="category">Objeto com os dados atualizados da categoria.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        /// <exception cref="KeyNotFoundException">Lançado quando a categoria não for encontrada.</exception>
        public async Task UpdateCategoryAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.GetByIdAsync(id);

            if (existingCategory == null)
            {
                throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
            }

            // Validar ou aplicar regras de negócios antes de atualizar

            // Atualizar nome da categoria
            existingCategory.UpdateName(category.Name);

            // Salvar a categoria atualizada
            await _categoryRepository.UpdateAsync(existingCategory);
        }

        /// <summary>
        /// Exclui uma categoria do sistema (exclusão lógica).
        /// </summary>
        /// <param name="id">ID da categoria a ser excluída.</param>
        /// <returns>Task que representa a operação assíncrona.</returns>
        /// <exception cref="KeyNotFoundException">Lançado quando a categoria não for encontrada.</exception>
        /// <exception cref="InvalidOperationException">Lançado quando a categoria já foi excluída.</exception>
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
            {
                throw new KeyNotFoundException($"Categoria com ID {id} não encontrada.");
            }

            // Verificar se a categoria já foi excluída
            if (category.IsDeleted)
            {
                throw new InvalidOperationException($"Categoria com ID {id} já foi excluída.");
            }

            // Marcar a categoria como deletada, sem removê-la fisicamente
            category.Delete();

            // Salvar a categoria marcada como excluída
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
