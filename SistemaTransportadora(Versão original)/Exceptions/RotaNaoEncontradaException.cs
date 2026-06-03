using System;

namespace SistemaTransportadora.Exceptions
{
    public class RotaNaoEncontradaException : Exception
    {
        public RotaNaoEncontradaException()
            : base("A rota especificada não existe no sistema.") { }

        public RotaNaoEncontradaException(string mensagem)
            : base(mensagem) { }
    }
}
