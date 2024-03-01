using CheckAPI.Domain.Base;
using CheckAPI.Domain.Inspecoes.Entities;

namespace CheckAPI.Domain.Inspecoes
{
    public class Inspecao : AggregateRoot
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Inspecao() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Inspecao(Veiculo veiculo, Executor executor)
        {
            Veiculo = veiculo;
            IdExecutor = executor.Id;
            Executor = executor;
            Status = EStatus.EmExecucao;
        }

        public Guid IdVeiculo { get; }
        public Veiculo Veiculo { get; }

        public Guid IdExecutor { get; }
        public Executor Executor { get; }

        public Guid? IdSupervisor { get; private set; }
        public Supervisor? Supervisor { get; private set; }

        public ICollection<RelatorioDeInspecao> Relatorios { get; } = new HashSet<RelatorioDeInspecao>();

        public EConclusao? Conclusao { get; private set; }
        public EStatus Status { get; private set; }

        public void AdicionarRelatorios(List<RelatorioDeInspecao> itens)
        {
            foreach (RelatorioDeInspecao item in itens)
                Relatorios.Add(item);
            Status = EStatus.AguardandoConclusao;
        }

        public void Concluir(Supervisor supervisor, EConclusao conclusao)
        {
            Supervisor = supervisor;
            IdSupervisor = supervisor.Id;
            Conclusao = conclusao;
            Status = EStatus.Concluido;
        }
    }

    public class Veiculo : Entity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Veiculo() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        // Esse construtor só existe para fins de teste
        public Veiculo(string marca, string modelo, int ano, string placa, string cor)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Placa = placa;
            Cor = cor;
        }

        public ICollection<Inspecao> Inspecoes { get; } = new HashSet<Inspecao>();

        public string Marca { get; }
        public string Modelo { get; }
        public int Ano { get; }
        public string Placa { get; }
        public string Cor { get; }
    }

    public class Funcionario : Entity
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        protected Funcionario() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Funcionario(long matricula, string nome, string telefone, string email, ECargo cargo) : base()
        {
            Matricula = matricula;
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Cargo = cargo;
        }

        public long Matricula { get; }
        public string Nome { get; }
        public string Telefone { get; }
        public string Email { get; }
        public ECargo Cargo { get; }
        public ICollection<Inspecao> Inspecoes { get; } = new HashSet<Inspecao>();
    }

    public enum ECargo
    {
        Executor,
        Supervisor
    }

    public class Executor : Funcionario
    {
        protected Executor() { }
        public Executor(long matricula, string nome, string telefone, string email, ECargo cargo) : base(matricula, nome, telefone, email, cargo) { }
    }
    public class Supervisor : Funcionario
    {
        protected Supervisor() { }
        public Supervisor(long matricula, string nome, string telefone, string email, ECargo cargo) : base(matricula, nome, telefone, email, cargo) { }
    }

    public enum EConclusao
    {
        Aprovado = 1,
        Reprovado = 2
    }

    public enum EStatus
    {
        EmExecucao = 1,
        AguardandoConclusao = 2, // Nome melhor?? Quando o supervisor precisa aprovar ou reprovar
        Concluido = 3,
        Cancelado = 4
    }
}
