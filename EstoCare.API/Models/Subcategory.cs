using EstoCare.API.Models;

using System.ComponentModel.DataAnnotations;

namespace EstoCare.API.Models
{
    /// <summary>
    /// Representa uma subcategoria de produtos dentro de uma categoria.
    /// </summary>
    public class Subcategory
    {
        /// <summary>
        /// Identificador único da subcategoria.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome da subcategoria.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Data de criação da subcategoria.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da última atualização da subcategoria.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Indicador de exclusão lógica da subcategoria.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Lista de produtos associados à subcategoria.
        /// </summary>
        public ICollection<Product> Products { get; set; }
    }
}