using CheckAPI.Application.Base;

namespace CheckAPI.Application.Commands.Views
{
    public class IniciarConfiguracaoInspecaoView(Guid id, DateTime dataCadastro, string nome) : View
    {
        public Guid Id { get; set; } = id;
        public DateTime DataCadastro { get; set; } = dataCadastro;
        public string Nome { get; set; } = nome;
    }
}
