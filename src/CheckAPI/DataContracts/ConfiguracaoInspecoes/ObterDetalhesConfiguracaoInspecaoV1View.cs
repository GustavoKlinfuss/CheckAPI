using CheckAPI.Application.Base;

namespace CheckAPI.DataContracts.ConfiguracaoInspecoes
{
    public class ObterDetalhesConfiguracaoInspecaoV1View(Guid id, string nome, IEnumerable<ObterDetalhesConfiguracaoInspecaoV1View.Inspecionavel> inspecionaveis) : View
    {
        public Guid Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public IEnumerable<Inspecionavel> Inspecionaveis { get; set; } = inspecionaveis;

        public class Inspecionavel
        {
            public Inspecionavel(Guid id, string titulo, string descricao, int tipoPreenchimento, int configObservacao)
            {
                Id = id;
                Titulo = titulo;
                Descricao = descricao;
                TipoPreenchimento = tipoPreenchimento;
                ConfigObservacao = configObservacao;
            }

            public Guid Id { get; }
            public string Titulo { get; }
            public string Descricao { get; }
            public int TipoPreenchimento { get; }
            public int ConfigObservacao { get; }

        }
    }
}
