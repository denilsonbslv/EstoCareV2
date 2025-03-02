using EstoCare.API.Models;

using System.ComponentModel.DataAnnotations;

namespace EstoCare.API.Models
{
    /// <summary>
    /// Representa uma categoria de produtos.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Identificador único da categoria.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da categoria.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Data de criação da categoria.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da última atualização da categoria.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Indicador de exclusão lógica da categoria.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Lista de produtos associados à categoria.
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}