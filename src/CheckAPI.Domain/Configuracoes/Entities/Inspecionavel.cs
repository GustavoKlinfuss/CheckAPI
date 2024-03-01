using CheckAPI.Domain.Base;

namespace CheckAPI.Domain.Configuracoes.Entities
{
    public class Inspecionavel : Entity
    {
        protected Inspecionavel() { }

        public Inspecionavel(string titulo, string descricao, ETipoPreenchimento tipoPreenchimento, EConfigObservacao configObsevacao)
        {
            Titulo = titulo;
            Descricao = descricao;
            TipoPreenchimento = tipoPreenchimento;
            ConfigObservacao = configObsevacao;
        }

        public Guid IdConfiguracaoInspecao { get; }
        public ConfiguracaoInspecao ConfiguracaoInspecao { get; }
        public string Titulo { get; }
        public string Descricao { get; }
        public ETipoPreenchimento TipoPreenchimento { get; }
        public EConfigObservacao ConfigObservacao { get; }
    }

    public enum ETipoPreenchimento
    {
        Check = 1,
        Data = 2,
        Inteiro = 3,
        Contabil = 4,
        Texto = 5
    }

    public enum EConfigObservacao
    {
        SemObservacao = 1,
        ObservacaoOpcional = 2,
        ObservacaoObrigatoriaSeAssinalado = 3,
        ObservacaoObrigatoria = 4
    }
}
