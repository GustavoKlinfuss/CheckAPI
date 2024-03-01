using CheckAPI.Domain.Configuracoes;
using CheckAPI.Domain.Configuracoes.Entities;
using CheckAPI.Domain.Inspecoes;
using System.Text.Json;

var _veiculos = new HashSet<Veiculo>()
{
    new("Chevrolet", "Impala", 1967, "III9999", "Preto"),
    new("Mercedes Benz", "Sprinter", 2011, "AAA0000", "Branco"),
    new("Mercedes Benz", "A230", 2021, "KSK9292", "Cinza")
};

var _funcionarios = new HashSet<Funcionario>()
{
    new Executor(1, "John Keynes", "41999999999", "teste@gmail.com", ECargo.Executor),
    new Supervisor(2, "John Keynes", "41999999999", "teste@gmail.com", ECargo.Supervisor),
    new Executor(3, "John Keynes", "41999999999", "teste@gmail.com", ECargo.Executor)
};

var _inspecoes = new HashSet<Inspecao>();

static void Print<T>(T obj)
{
    Console.WriteLine("--------------------------------------------------------------------------------------");
    Console.WriteLine(JsonSerializer.Serialize(obj, new JsonSerializerOptions() { WriteIndented = true }));
}

// Caso de uso 1 (Administrador) -> Criar configuração
var config = new ConfiguracaoInspecao("Inspeção veícular rápida");

// Caso de uso 2 (Administrador) -> Criar inspecionaveis
config.Adicionar(
    new Inspecionavel(
        "Faróis",
        "Faróis estão de acordo com o esperado?",
        ETipoPreenchimento.Check,
        EConfigObservacao.ObservacaoOpcional));

config.Adicionar(
    new Inspecionavel(
        "Freios",
        "Freios estão de acordo com o esperado?",
        ETipoPreenchimento.Check,
        EConfigObservacao.ObservacaoOpcional));

config.Adicionar(
    new Inspecionavel(
        "Substituição de itens",
        "É necessária a substituição de algum item?",
        ETipoPreenchimento.Check,
        EConfigObservacao.ObservacaoObrigatoriaSeAssinalado));

Print(config);

// Caso de uso 3 (Executor) -> Obter rodas configurações de inspeção // Obter detalhes de única configuração de inspeção
var viewInspecionaveis = config.Inspecionaveis.Select(x => new
{
    x.Titulo,
    x.Descricao,
    x.TipoPreenchimento,
    ConfigObservacao = x.ConfigObservacao.ToString()
});

Print(viewInspecionaveis);

// Caso de uso 4 (Executor) -> Iniciar inspeção (validar se não há outro executor inspecionando o mesmo veículo)
var placaSelecionada = "AAA0000";
var veiculo = _veiculos.FirstOrDefault(x => x.Placa == placaSelecionada);

if (veiculo == null
    || veiculo.Inspecoes.Any(x => x.Status == EStatus.EmExecucao
                               || x.Status == EStatus.AguardandoConclusao))
    throw new Exception("Veiculo indisponível para inspeção");

var matriculaDesseIndividuo = 1;

var funcionario = _funcionarios.FirstOrDefault(x => x.Matricula == matriculaDesseIndividuo);

if (funcionario is null || funcionario.Cargo != ECargo.Executor)
    throw new Exception("Executor não encontrado no sistema");

var inspecao = new Inspecao(
    veiculo,
    (Executor)funcionario);

Print(inspecao);

// Caso de uso 5 (Executor) -> Adicionar relatórios
inspecao.AdicionarRelatorios(
    [
        new("Faróis", "true", null),
        new("Freios", "false", "Quase fim da vida"),
        new("Substituição de itens", "true", "Retrovisor direito"),
    ]);

Print(inspecao);

var matriculaDoSupervisor = 2;
var teoricamenteOSupervisor = _funcionarios.FirstOrDefault(x => x.Matricula == matriculaDoSupervisor);

if (teoricamenteOSupervisor is null || teoricamenteOSupervisor.Cargo != ECargo.Supervisor)
    throw new Exception("Supervisor não encontrado no sistema");

// Caso de uso 6 (Supervisor) -> Finalizar inspeção
inspecao.Concluir((Supervisor)teoricamenteOSupervisor, EConclusao.Aprovado);

Print(inspecao);
