using EstoCare.API.Models.DTOs;
using EstoCare.Application.Interfaces;
using EstoCare.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstoCare.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Construtor com injeção de dependência do serviço de categorias.
        /// </summary>
        /// <param name="categoryService">Serviço de categorias.</param>
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Obtém todas as categorias cadastradas.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtém todas as categorias", Description = "Retorna uma lista de todas as categorias cadastradas.")]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), 200)]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            var categoryDtos = categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });

            return Ok(categoryDtos);
        }

        /// <summary>
        /// Obtém uma categoria específica pelo ID.
        /// </summary>
        /// <param name="id">ID da categoria.</param>
        /// <returns>Categoria correspondente ao ID.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma categoria por ID", Description = "Busca uma categoria pelo seu identificador único.")]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound(new { Message = "Categoria não encontrada." });

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };

            return Ok(categoryDto);
        }

        /// <summary>
        /// Obtém uma categoria específica pelo nome.
        /// </summary>
        /// <param name="name">Nome da categoria.</param>
        /// <returns>Categoria correspondente ao nome.</returns>
        [HttpGet("name/{name}")]
        [SwaggerOperation(Summary = "Obtém uma categoria por nome", Description = "Busca uma categoria pelo seu nome.")]
        [ProducesResponseType(typeof(CategoryDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            var category = await _categoryService.GetCategoryByNameAsync(name);
            if (category == null)
                return NotFound(new { Message = "Categoria não encontrada." });
            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };
            return Ok(categoryDto);
        }

        /// <summary>
        /// Cria uma nova categoria.
        /// </summary>
        /// <param name="createCategoryDto">Dados da nova categoria.</param>
        /// <returns>Categoria criada.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova categoria", Description = "Adiciona uma nova categoria ao sistema.")]
        [ProducesResponseType(typeof(CategoryDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
        {
            if (string.IsNullOrWhiteSpace(createCategoryDto.Name))
                return BadRequest(new { Message = "O nome da categoria é obrigatório." });

            var newCategory = new Category(createCategoryDto.Name);
            var createdCategory = await _categoryService.CreateCategoryAsync(newCategory);

            var categoryDto = new CategoryDto
            {
                Id = createdCategory.Id,
                Name = createdCategory.Name,
                CreatedAt = createdCategory.CreatedAt
            };

            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDto.Id }, categoryDto);
        }

        /// <summary>
        /// Atualiza uma categoria existente.
        /// </summary>
        /// <param name="id">ID da categoria a ser atualizada.</param>
        /// <param name="updateCategoryDto">Novos dados da categoria.</param>
        /// <returns>Resposta da atualização.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma categoria", Description = "Modifica os dados de uma categoria existente.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            if (string.IsNullOrWhiteSpace(updateCategoryDto.Name))
                return BadRequest(new { Message = "O nome da categoria é obrigatório." });

            try
            {
                await _categoryService.UpdateCategoryAsync(id, new Category(updateCategoryDto.Name));
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Categoria não encontrada." });
            }
        }

        /// <summary>
        /// Exclui (logicamente) uma categoria pelo ID.
        /// </summary>
        /// <param name="id">ID da categoria a ser excluída.</param>
        /// <returns>Resposta da exclusão.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Exclui uma categoria", Description = "Realiza a exclusão lógica de uma categoria.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Categoria não encontrada." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
