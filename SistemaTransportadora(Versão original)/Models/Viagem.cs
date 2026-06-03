using SistemaTransportadora.Interfaces;
using System;

namespace SistemaTransportadora.Models
{
    public class Viagem : IRegistavel
    {
        private string _codigo;
        private DateTime _dataViagem;
        private Veiculo _veiculo;
        private Motorista _motorista;
        private Rota _rota;
        private double _custoTotal;
        private EstadoViagem _estado;

        public string Codigo
        {
            get { return _codigo; }
            set { if (!string.IsNullOrEmpty(value)) _codigo = value.ToUpper(); }
        }

        public DateTime DataViagem
        {
            get { return _dataViagem; }
            set { _dataViagem = value; }
        }

        public Veiculo Veiculo
        {
            get { return _veiculo; }
            set { if (value != null) _veiculo = value; }
        }

        public Motorista Motorista
        {
            get { return _motorista; }
            set { if (value != null) _motorista = value; }
        }

        public Rota Rota
        {
            get { return _rota; }
            set { if (value != null) _rota = value; }
        }

        public double CustoTotal
        {
            get { return _custoTotal; }
            private set { if (value >= 0) _custoTotal = value; }
        }

        public EstadoViagem Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    // Construtor de viagem
        public Viagem(string codigo, DateTime dataViagem, Veiculo veiculo, Motorista motorista, Rota rota)
        {
            Codigo = codigo;
            DataViagem = dataViagem;
            Veiculo = veiculo;
            Motorista = motorista;
            Rota = rota;
            CustoTotal = rota.DistanciaKm * veiculo.ConsumoPorKm;
            _estado = EstadoViagem.Agendada;
        }

        public string ObterCodigo() => Codigo;

        public string MostrarDados()
            => $"Código: {Codigo} | Data: {DataViagem:dd/MM/yyyy HH:mm} | " +
               $"Veículo: {Veiculo.Matricula} | Motorista: {Motorista.Nome} | " +
               $"Rota: {Rota.Origem} -> {Rota.Destino} | " +
               $"Custo: {CustoTotal:F2} kz | Estado: {Estado}";
        
    }
}
