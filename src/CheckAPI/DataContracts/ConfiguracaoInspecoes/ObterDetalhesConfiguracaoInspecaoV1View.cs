using CheckAPI.Application.Base;

namespace CheckAPI.DataContracts.ConfiguracaoInspecoes
{
    public class ObterDetalhesConfiguracaoInspecaoV1View(Guid id) : View
    {
        public Guid Id { get; set; } = id;
    }
}
