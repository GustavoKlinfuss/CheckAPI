using CheckAPI.Application.Base;
using MediatR;
using System.Runtime.Serialization;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao
{
    [DataContract]
    public class IniciarConfiguracaoInspecaoCommand(string nome) : IRequest<BaseResult>
    {
        [DataMember]
        public string Nome { get; set; } = nome;
    }
}
