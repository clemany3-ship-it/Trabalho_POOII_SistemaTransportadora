
using Sistema_Transportadora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Interface
{
    public interface IRepository<T>
    {
        void Adicionar(T item);
        T ObterPorCodigo(string codigo);
        List<T> ObterTodos();
        void Remover(string codi);
    }
}
