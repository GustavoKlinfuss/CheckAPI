namespace CheckAPI.Application.Base
{
    public class BaseResult
    {
        public bool Sucesso => Erros is null;
        public IEnumerable<CommandExecutionError>? Erros { get; set; }
        public object? Dados { get; set; }

        public BaseResult(object dados)
        {
            Dados = dados;
        }

        public BaseResult(IEnumerable<CommandExecutionError> erros)
        {
            Erros = erros;
        }
    }

    public class CommandExecutionError(string codigo, string mensagem)
    {
        public string Codigo { get; set; } = codigo;
        public string Mensagem { get; set; } = mensagem;
    }
}
