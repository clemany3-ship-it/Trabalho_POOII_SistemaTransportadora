using System;

namespace SistemaTransportadora.Exceptions
{
    public class RegistoDuplicadoException : Exception
    {
        public RegistoDuplicadoException()
            : base("Já existe um registo com esse código no sistema.") { }

        public RegistoDuplicadoException(string mensagem)
            : base(mensagem) { }
    }
}
