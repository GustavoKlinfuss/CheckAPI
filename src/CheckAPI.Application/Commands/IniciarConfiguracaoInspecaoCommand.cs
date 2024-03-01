using CheckAPI.Application.Base;
using CheckAPI.Application.Commands.Views;
using MediatR;
using System.Runtime.Serialization;

namespace CheckAPI.Application.Commands
{
    [DataContract]
    public class IniciarConfiguracaoInspecaoCommand(string nome) : IRequest<BaseResult<IniciarConfiguracaoInspecaoView>>
    {
        [DataMember]
        public string Nome { get; set; } = nome;
    }
}
