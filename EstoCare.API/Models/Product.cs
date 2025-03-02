using System.ComponentModel.DataAnnotations;

namespace EstoCare.API.Models
{
    /// <summary>
    /// Representa um produto dentro do sistema.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// Descrição detalhada do produto.
        /// </summary>
        [MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        [Range(0, double.MaxValue, ErrorMessage = "O preço não pode ser negativo.")]
        public decimal Price { get; set; }

        /// <summary>
        /// Quantidade em estoque do produto.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "O estoque não pode ser negativo.")]
        public int Stock { get; set; }

        /// <summary>
        /// Data de criação do produto.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Data da última atualização do produto.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Indicador de exclusão lógica do produto.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Identificador da categoria associada ao produto.
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Categoria à qual o produto pertence.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Identificador da subcategoria associada ao produto (opcional).
        /// </summary>
        public int? SubcategoryId { get; set; }

        /// <summary>
        /// Subcategoria à qual o produto pertence (opcional).
        /// </summary>
        public Subcategory Subcategory { get; set; }
    }
}