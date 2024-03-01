namespace CheckAPI.Domain.Base
{
    public class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public DateTime DataCadastro { get; } = DateTime.Now;
        public DateTime? DataUltimaModificacao { get; set; }
    }
}
