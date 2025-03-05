using EstoCare.Domain.Common;
using System;

namespace EstoCare.Domain.Entities
{
    /// <summary>
    /// Representa um produto dentro de uma categoria.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Quantidade em estoque.
        /// </summary>
        public int StockQuantity { get; private set; }

        /// <summary>
        /// Identificador da categoria à qual o produto pertence.
        /// </summary>
        public int CategoryId { get; private set; }

        /// <summary>
        /// Categoria à qual o produto pertence.
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Construtor da entidade Product.
        /// </summary>
        /// <param name="name">Nome do produto.</param>
        /// <param name="description">Descrição do produto.</param>
        /// <param name="price">Preço do produto.</param>
        /// <param name="stockQuantity">Quantidade em estoque.</param>
        /// <param name="categoryId">Identificador da categoria do produto.</param>
        public Product(string name, string description, decimal price, int stockQuantity, int categoryId)
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetStockQuantity(stockQuantity);
            SetCategory(categoryId);
        }

        /// <summary>
        /// Atualiza o nome do produto.
        /// </summary>
        /// <param name="newName">Novo nome do produto.</param>
        public void UpdateName(string newName)
        {
            SetName(newName);
            UpdateTimestamp();
        }

        /// <summary>
        /// Atualiza a descrição do produto.
        /// </summary>
        /// <param name="newDescription">Nova descrição do produto.</param>
        public void UpdateDescription(string newDescription)
        {
            SetDescription(newDescription);
            UpdateTimestamp();
        }

        /// <summary>
        /// Atualiza o preço do produto.
        /// </summary>
        /// <param name="newPrice">Novo preço do produto.</param>
        public void UpdatePrice(decimal newPrice)
        {
            SetPrice(newPrice);
            UpdateTimestamp();
        }

        /// <summary>
        /// Atualiza a quantidade em estoque do produto.
        /// </summary>
        /// <param name="newQuantity">Nova quantidade em estoque.</param>
        public void UpdateStockQuantity(int newQuantity)
        {
            SetStockQuantity(newQuantity);
            UpdateTimestamp();
        }

        /// <summary>
        /// Marca o produto como excluído (exclusão lógica).
        /// </summary>
        public void Delete()
        {
            MarkAsDeleted();
        }

        /// <summary>
        /// Método privado para validar e definir o nome do produto.
        /// </summary>
        /// <param name="name">Nome do produto.</param>
        /// <exception cref="ArgumentException">Lança uma exceção se o nome for inválido.</exception>
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome do produto não pode ser vazio.");

            Name = name;
        }

        /// <summary>
        /// Método privado para validar e definir a descrição do produto.
        /// </summary>
        /// <param name="description">Descrição do produto.</param>
        private void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("A descrição do produto não pode ser vazia.");

            Description = description;
        }

        /// <summary>
        /// Método privado para validar e definir o preço do produto.
        /// </summary>
        /// <param name="price">Preço do produto.</param>
        private void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("O preço do produto deve ser maior que zero.");

            Price = price;
        }

        /// <summary>
        /// Método privado para validar e definir a quantidade em estoque do produto.
        /// </summary>
        /// <param name="stockQuantity">Quantidade em estoque do produto.</param>
        private void SetStockQuantity(int stockQuantity)
        {
            if (stockQuantity < 0)
                throw new ArgumentException("A quantidade em estoque não pode ser negativa.");

            StockQuantity = stockQuantity;
        }

        /// <summary>
        /// Método privado para definir a categoria do produto.
        /// </summary>
        /// <param name="categoryId">Identificador da categoria do produto.</param>
        private void SetCategory(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("O identificador da categoria deve ser válido.");

            CategoryId = categoryId;
        }
    }
}
