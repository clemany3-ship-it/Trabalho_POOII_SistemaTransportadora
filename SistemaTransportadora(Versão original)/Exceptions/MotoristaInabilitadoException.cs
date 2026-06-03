using System;

namespace SistemaTransportadora.Exceptions
{
    public class MotoristaInabilitadoException : Exception
    {
        public MotoristaInabilitadoException()
            : base("O motorista não está activo ou não possui carta adequada.") { }

        public MotoristaInabilitadoException(string mensagem)
            : base(mensagem) { }
    }
}
