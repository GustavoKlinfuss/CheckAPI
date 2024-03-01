using CheckAPI.Application.Base;
using CheckAPI.Application.Commands.ConfiguracoesInspecao.Views;
using MediatR;
using System.Runtime.Serialization;

namespace CheckAPI.Application.Commands.ConfiguracoesInspecao
{
    [DataContract]
    public class IniciarConfiguracaoInspecaoCommand(string nome) : IRequest<BaseResult<IniciarConfiguracaoInspecaoView>>
    {
        [DataMember]
        public string Nome { get; set; } = nome;
    }
}
