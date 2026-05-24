using Sistema_Transportadora.Modelos;
using Sistema_Transportadora.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Servicos
{
    public class RotaServico
    {
        private readonly RotaRepository _repositorio;
        public RotaServico()
        {
            _repositorio = new RotaRepository();

        }

        public void AdicionarRota(Rota rota)
        {
            if (rota == null)
                throw new ArgumentNullException("Dados da Rota não podem ser vazio");
            _repositorio.Adicionar(rota);

        }
        public Rota ProcurarPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) 
                throw new Exception(" Codigo da Rota Invalida");
            var rota=_repositorio.ObterPorCodigo(codigo);
            if (rota == null)
                throw new Rota_N_esxisteException();
            return rota;
        }

        public List<Rota> ListarTodos()
        {
            return _repositorio.ObterTodos();
        }

    }
}
