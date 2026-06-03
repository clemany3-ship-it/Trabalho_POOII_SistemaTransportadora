using SistemaTransportadora.Interfaces;

namespace SistemaTransportadora.Models
{
    public class Veiculo : IRegistavel
    {
        private string _matricula;
        private TipoVeiculo _tipo;
        private int _capacidadeCarga;
        private EstadoVeiculo _estado;
        private double _consumoPorKm;

        public string Matricula
        {
            get { return _matricula; }
            set { if (!string.IsNullOrEmpty(value)) _matricula = value.ToUpper(); }
        }

        public TipoVeiculo Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        public int Capacidade
        {
            get { return _capacidadeCarga; }
            set { if (value > 0) _capacidadeCarga = value; }
        }

        public EstadoVeiculo Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public double ConsumoPorKm
        {
            get { return _consumoPorKm; }
            set { if (value >= 0) _consumoPorKm = value; }
        }

        public Veiculo(string matricula, TipoVeiculo tipo, int capacidade, double consumo)
        {
            Matricula = matricula;
            _tipo = tipo;
            Capacidade = capacidade;
            ConsumoPorKm = consumo;
            _estado = EstadoVeiculo.Disponivel;
        }

        public string ObterCodigo() => Matricula;

        public string MostrarDados()
            => $"Matrícula: {Matricula} | Tipo: {Tipo} | Capacidade: {Capacidade} kg | " +
               $"Consumo: {ConsumoPorKm} L/km | Estado: {Estado}";
    }
}
