namespace CheckAPI.Domain.Inspecoes.Services
{
    public interface IGatewayVeiculos
    {
        public Task<Veiculo?> ObterVeiculoPorPlaca(string placa);
    }
}
