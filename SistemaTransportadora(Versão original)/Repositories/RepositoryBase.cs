using SistemaTransportadora.Exceptions;
using SistemaTransportadora.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaTransportadora.Repositories
{
    public class RepositoryBase<T> : IRepositorio<T> where T : IRegistavel
    {
        protected List<T> _lista = new List<T>();

        public void Adicionar(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Item não pode ser nulo.");

            if (_lista.Any(x => x.ObterCodigo() == item.ObterCodigo()))
                throw new RegistoDuplicadoException($"Já existe um registo com o código '{item.ObterCodigo()}'.");

            _lista.Add(item);
        }

        public T ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentNullException("Código não pode ser vazio.");

            return _lista.FirstOrDefault(x => x.ObterCodigo() == codigo.ToUpper());
        }

        public List<T> ObterTodos()
        {
            return new List<T>(_lista);
        }

        public void Remover(string codigo)
        {
            var item = ObterPorCodigo(codigo);
            if (item == null)
                throw new Exception($"Registo com código '{codigo}' não encontrado.");

            _lista.Remove(item);
        }
    }
}
