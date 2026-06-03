using SistemaTransportadora.Exceptions;
using SistemaTransportadora.Models;
using SistemaTransportadora.Repositories;
using System;
using System.Collections.Generic;

namespace SistemaTransportadora.Services
{
    public class VeiculoService
    {
        private readonly VeiculoRepository _repositorio;

        public VeiculoService()
        {
            _repositorio = new VeiculoRepository();
        }

        public void Adicionar(Veiculo veiculo)
        {
            if (veiculo == null)
                throw new ArgumentNullException("Dados do veículo não podem ser nulos.");
            _repositorio.Adicionar(veiculo);
        }

        public Veiculo ObterPorMatricula(string matricula)
        {
            if (string.IsNullOrEmpty(matricula))
                throw new ArgumentNullException("Matrícula inválida.");
            var veiculo = _repositorio.ObterPorCodigo(matricula);
            if (veiculo == null)
                throw new Exception($"Veículo com matrícula '{matricula}' não encontrado.");
            return veiculo;
        }

        public List<Veiculo> ListarTodos() => _repositorio.ObterTodos();

        public void Remover(string matricula)
        {
            var veiculo = ObterPorMatricula(matricula);
            if (veiculo.Estado == EstadoVeiculo.Em_Viagem)
                throw new VeiculoIndisponivelException("Não é possível remover um veículo em viagem.");
            _repositorio.Remover(matricula);
        }

        public void AlterarEstado(string matricula, EstadoVeiculo novoEstado)
        {
            var veiculo = ObterPorMatricula(matricula);
            veiculo.Estado = novoEstado;
        }
    }
}
