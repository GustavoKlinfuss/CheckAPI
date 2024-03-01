using CheckAPI.Application.Base;
using System.Runtime.Serialization;

namespace CheckAPI.DataContracts.ConfiguracaoInspecoes
{
    [DataContract]
    public class ObterConfiguracoesInspecaoV1View(IEnumerable<ObterConfiguracoesInspecaoV1View.ConfiguracaoInspecao> configuracoes) : View
    {
        [DataMember]
        public IEnumerable<ConfiguracaoInspecao> Configuracoes { get; } = configuracoes;

        [DataContract]
        public class ConfiguracaoInspecao(Guid id)
        {
            [DataMember]
            public Guid Id { get; } = id;
        }
    }
}
