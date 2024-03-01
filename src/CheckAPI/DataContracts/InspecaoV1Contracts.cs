namespace CheckAPI.DataContracts
{
    public class InspecaoV1Contracts
    {
        public record IniciarInspecaoV1Request(long Matricula, string Placa);
        public record IniciarInspecaoV1Response(Guid IdInspecao);
    }

    
}
