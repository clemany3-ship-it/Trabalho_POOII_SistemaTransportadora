using System.Collections.Generic;

namespace SistemaTransportadora.Interfaces
{
    public interface IRepositorio<T>
    {
        void Adicionar(T item);
        T ObterPorCodigo(string codigo);
        List<T> ObterTodos();
        void Remover(string codigo);
    }
}
