using EstoCare.Domain.Common;

namespace EstoCare.Domain.Entities
{
    /// <summary>
    /// Representa uma categoria de produtos.
    /// </summary>
    public class Category : BaseEntity
    {
        /// <summary>
        /// Nome da categoria.
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// Lista de produtos associados à categoria.
        /// </summary>
        public ICollection<Product> Products { get; private set; } = new List<Product>();


        /// <summary>
        /// Construtor da entidade Category.
        /// </summary>
        /// <param name="name">Nome da categoria.</param>
        public Category(string name)
        {
            SetName(name); // Chama o método SetName no construtor para garantir a validação e definição do nome
        }

        /// <summary>
        /// Atualiza o nome da categoria.
        /// </summary>
        /// <param name="newName">Novo nome da categoria.</param>
        public void UpdateName(string newName)
        {
            SetName(newName);  // Atualiza o nome chamando o método SetName
            UpdateTimestamp();  // Atualiza a data de modificação (o método UpdateTimestamp deve estar no BaseEntity)
        }

        /// <summary>
        /// Marca a categoria como excluída (exclusão lógica).
        /// </summary>
        public void Delete()
        {
            MarkAsDeleted();  // Marca como deletado, de forma lógica
        }

        /// <summary>
        /// Método privado para validar e definir o nome da categoria.
        /// </summary>
        /// <param name="name">Nome da categoria.</param>
        /// <exception cref="ArgumentException">Lança uma exceção se o nome for inválido.</exception>
        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome da categoria não pode ser vazio.");

            Name = name;  // Define o nome após a validação
        }
    }
}
