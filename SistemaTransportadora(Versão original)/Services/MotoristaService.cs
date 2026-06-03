using SistemaTransportadora.Exceptions;
using SistemaTransportadora.Models;
using SistemaTransportadora.Repositories;
using System;
using System.Collections.Generic;

namespace SistemaTransportadora.Services
{
    public class MotoristaService
    {
        private readonly MotoristaRepository _repositorio;

        public MotoristaService()
        {
            _repositorio = new MotoristaRepository();
        }

        public void Adicionar(Motorista motorista)
        {
            if (motorista == null)
                throw new ArgumentNullException("Dados do motorista não podem ser nulos.");
            _repositorio.Adicionar(motorista);
        }

        public Motorista ObterPorCarta(string numeroCarta)
        {
            if (string.IsNullOrEmpty(numeroCarta))
                throw new ArgumentNullException("Número de carta inválido.");
            var motorista = _repositorio.ObterPorCodigo(numeroCarta);
            if (motorista == null)
                throw new Exception($"Motorista com carta '{numeroCarta}' não encontrado.");
            return motorista;
        }

        public List<Motorista> ListarTodos() => _repositorio.ObterTodos();

        public void Remover(string numeroCarta)
        {
            _repositorio.Remover(numeroCarta);
        }

        public void Desativar(string numeroCarta)
        {
            var motorista = ObterPorCarta(numeroCarta);
            motorista.EstadoActivo = false;
        }

        public void Ativar(string numeroCarta)
        {
            var motorista = ObterPorCarta(numeroCarta);
            motorista.EstadoActivo = true;
        }
    }
}
