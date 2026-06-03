using SistemaTransportadora.Exceptions;
using SistemaTransportadora.Models;
using SistemaTransportadora.Repositories;
using System;
using System.Collections.Generic;

namespace SistemaTransportadora.Services
{
    public class RotaService
    {
        private readonly RotaRepository _repositorio;

        public RotaService()
        {
            _repositorio = new RotaRepository();
        }

        public void Adicionar(Rota rota)
        {
            if (rota == null)
                throw new ArgumentNullException("Dados da rota não podem ser nulos.");
            _repositorio.Adicionar(rota);
        }

        public Rota ObterPorCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentNullException("Código da rota inválido.");
            var rota = _repositorio.ObterPorCodigo(codigo);
            if (rota == null)
                throw new RotaNaoEncontradaException($"Rota '{codigo}' não encontrada.");
            return rota;
        }

        public List<Rota> ListarTodos() => _repositorio.ObterTodos();

        public void Remover(string codigo)
        {
            _repositorio.Remover(codigo);
        }
    }
}
