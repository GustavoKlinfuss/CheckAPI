using CheckAPI.Domain.Base;
using CheckAPI.Domain.Configuracoes.Entities;

namespace CheckAPI.Domain.Configuracoes
{
    public class ConfiguracaoInspecao : AggregateRoot
    {
        private ConfiguracaoInspecao() { }

        public ConfiguracaoInspecao(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; } = null!;
        public ICollection<Inspecionavel> Inspecionaveis { get; } = new HashSet<Inspecionavel>();

        public void Adicionar(Inspecionavel inspecionavel)
        {
            Inspecionaveis.Add(inspecionavel);
        }
    }
}
