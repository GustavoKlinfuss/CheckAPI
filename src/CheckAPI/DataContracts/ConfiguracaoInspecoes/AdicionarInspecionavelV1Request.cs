using CheckAPI.Domain.Configuracoes.Entities;

namespace CheckAPI.DataContracts.ConfiguracaoInspecoes
{
    public class AdicionarInspecionavelV1Request
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Opcao> Opcoes { get; set; }
        public ETipoPreenchimento TipoPreenchimento { get; set; }
        public EConfigObservacao ConfiguracaoObservacao { get; set; }

        public record Opcao(string Titulo);
    }
}
