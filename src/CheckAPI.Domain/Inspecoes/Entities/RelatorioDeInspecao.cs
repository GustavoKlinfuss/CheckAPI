using CheckAPI.Domain.Base;

namespace CheckAPI.Domain.Inspecoes.Entities
{
    public class RelatorioDeInspecao : Entity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private RelatorioDeInspecao() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public RelatorioDeInspecao(string titulo, string valor, string? observacao)
        {
            Titulo = titulo;
            Valor = valor;
            Observacao = observacao;
        }

        public Guid InspecaoId { get; }
        public Inspecao Inspecao { get; }

        public string Titulo { get; }
        public string Valor { get; }
        public string? Observacao { get; }
    }
}
