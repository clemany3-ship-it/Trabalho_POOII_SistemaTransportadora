using System;

namespace SistemaTransportadora.Exceptions
{
    public class VeiculoIndisponivelException : Exception
    {
        public VeiculoIndisponivelException()
            : base("O veículo não está disponível para viagem.") { }

        public VeiculoIndisponivelException(string mensagem)
            : base(mensagem) { }
    }
}
