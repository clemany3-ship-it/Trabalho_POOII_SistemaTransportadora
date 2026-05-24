using Sistema_Transportadora.Modelos;
using Sistema_Transportadora.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Servicos
{
    internal class VeiculoService
    {
        private readonly VeiculoRepository _repositorio;
        
        public VeiculoService()
        {
            _repositorio = new VeiculoRepository();
        }

        // adicionar veiculo
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            if (veiculo == null) 
                throw new ArgumentNullException("Dados de veiculo não pode ser vaziios");
            _repositorio.Adicionar(veiculo);

        }
        // Procurar por matricula
        public Veiculo ProcurarPorMatricula(string matricula)
        {
            if (string.IsNullOrEmpty(matricula))
                throw new Exception("Matricula invalida");
            var  veiculo=_repositorio.ObterPorCodigo(matricula);
            if (veiculo == null)
                throw new Exception(" Veiculo não encontrado");
            return veiculo;
        }

        // Listar todos
        public List<Veiculo> ListarTodos()
        {
            return _repositorio.ObterTodos();
        }
        // Mudar estado do veiculo

        public void AlterarEstado(string matricula,Estado_Veiculo novoEstado)
        {
            var veiculo = ProcurarPorMatricula(matricula);
            veiculo.Estado = novoEstado;
        }
    }
}
