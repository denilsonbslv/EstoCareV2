namespace EstoCare.Domain.Common
{
    /// <summary>
    /// Classe base para todas as entidades do domínio.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identificador único.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Data de criação.
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Data da última atualização.
        /// </summary>
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Indicador de exclusão lógica.
        /// </summary>
        public bool IsDeleted { get; private set; } = false;

        /// <summary>
        /// Atualiza a data de modificação para manter rastreamento de alterações.
        /// </summary>
        protected void UpdateTimestamp()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Marca a entidade como excluída (exclusão lógica).
        /// </summary>
        protected void MarkAsDeleted()
        {
            IsDeleted = true;
            UpdateTimestamp();
        }
    }
}
