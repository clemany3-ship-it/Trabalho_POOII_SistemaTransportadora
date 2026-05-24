
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Sistema_Transportadora.Interface;

namespace Sistema_Transportadora.Repositorio
{
    public class RepositoryBase<T>:IRepository<T>where T:IRejistavel
    {

        protected List<T>_list = new List<T>();
        public void Adicionar(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Item não pode ser nulo");
            }
            if (_list.Any( x => x.Obter_codigo() == item.Obter_codigo()))
                throw new Exception("Existe registo já com esse código");
            
                     
            _list.Add(item);
        
           
        }
        public T Obter_codigo(string codigo)
        {

            return _list.FirstOrDefault(x => x.Obter_codigo()== codigo.ToUpper());
        }
        public List<T> ObterTodos()
        {
            return new List<T>(_list);
        }
        public void Remover(string codi)
        {
            var  item = ObterPorCodigo(codi);
            if (item != null)
                _list.Remove(item);
        }

        public T ObterPorCodigo(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
/*
 * 
        T IRepository<T>.obterPorCOdigo(string codi)
        {
            throw new NotImplementedException();
        }

        List<T> IRepository<T>.ObterTodos()
        {
            throw new NotImplementedException();
        }

        void IRepository<T>.Remover(string codi)
        {
            throw new NotImplementedException();
        }*/