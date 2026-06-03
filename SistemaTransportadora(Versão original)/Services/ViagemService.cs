using SistemaTransportadora.Exceptions;
using SistemaTransportadora.Models;
using SistemaTransportadora.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaTransportadora.Services
{
    public class ViagemService
    {
        private readonly ViagemRepository _repositorio;
        private readonly VeiculoService _veiculoService;
        private readonly MotoristaService _motoristaService;
        private readonly RotaService _rotaService;

        public ViagemService(VeiculoService veiculoService, MotoristaService motoristaService, RotaService rotaService)
        {
            _repositorio = new ViagemRepository();
            _veiculoService = veiculoService;
            _motoristaService = motoristaService;
            _rotaService = rotaService;
        }

        // Agenda uma viagem para uma data futura (estado = Agendada)
        public void Agendar(Viagem viagem)
        {
            if (viagem == null)
                throw new ArgumentNullException("Dados da viagem não podem ser nulos.");

            var veiculo = _veiculoService.ObterPorMatricula(viagem.Veiculo.Matricula);
            if (veiculo.Estado != EstadoVeiculo.Disponivel)
                throw new VeiculoIndisponivelException();

            var motorista = _motoristaService.ObterPorCarta(viagem.Motorista.NumeroCarta);
            if (!motorista.EstadoActivo)
                throw new MotoristaInabilitadoException();

            _rotaService.ObterPorCodigo(viagem.Rota.Codigo);

            viagem.Estado = EstadoViagem.Agendada;
            _repositorio.Adicionar(viagem);

            // Reserva o veículo imediatamente
            veiculo.Estado = EstadoVeiculo.Em_Viagem;
        }

        // Inicia uma viagem agendada (estado = EmCurso)
        public void Iniciar(string codigoViagem)
        {
            var viagem = ObterPorCodigo(codigoViagem);
            if (viagem.Estado != EstadoViagem.Agendada)
                throw new Exception($"Só é possível iniciar viagens no estado 'Agendada'. Estado actual: {viagem.Estado}");
            viagem.Estado = EstadoViagem.EmCurso;
        }

        // Conclui uma viagem em curso e liberta o veículo
        public void Concluir(string codigoViagem)
        {
            var viagem = ObterPorCodigo(codigoViagem);
            if (viagem.Estado != EstadoViagem.EmCurso && viagem.Estado != EstadoViagem.Agendada)
                throw new Exception($"Não é possível concluir uma viagem no estado '{viagem.Estado}'.");

            viagem.Estado = EstadoViagem.Concluida;
            viagem.Veiculo.Estado = EstadoVeiculo.Disponivel;
        }

        // Cancela e remove uma viagem, libertando o veículo
        public void Cancelar(string codigoViagem)
        {
            var viagem = ObterPorCodigo(codigoViagem);
            if (viagem.Estado == EstadoViagem.Concluida)
                throw new Exception("Não é possível cancelar uma viagem já concluída.");

            viagem.Estado = EstadoViagem.Cancelada;
            viagem.Veiculo.Estado = EstadoVeiculo.Disponivel;
            _repositorio.Remover(codigoViagem);
        }

        public Viagem ObterPorCodigo(string codigo)
        {
            var viagem = _repositorio.ObterPorCodigo(codigo);
            if (viagem == null)
                throw new Exception($"Viagem com código '{codigo}' não encontrada.");
            return viagem;
        }

        public List<Viagem> ListarTodas() => _repositorio.ObterTodos();

        public List<Viagem> ListarAgendadas()
            => _repositorio.ObterTodos().Where(v => v.Estado == EstadoViagem.Agendada).ToList();

        public List<Viagem> ListarEmCurso()
            => _repositorio.ObterTodos().Where(v => v.Estado == EstadoViagem.EmCurso).ToList();
    }
}
