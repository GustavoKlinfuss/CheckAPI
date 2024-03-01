using CheckAPI.Application.Base;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao.Views
{
    public class AdicionarInspecionavelView(Guid id) : View
    {
        public Guid Id { get; set; } = id;
    }
}
