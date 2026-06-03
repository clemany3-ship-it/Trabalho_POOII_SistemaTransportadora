using SistemaTransportadora.Interfaces;
using System;

namespace SistemaTransportadora.Models
{
    public class Manutencao : IRegistavel
    {
        private string _codigo;
        private DateTime _data;
        private string _descricao;
        private double _custo;
        private Veiculo _veiculo;

        public string Codigo
        {
            get { return _codigo; }
            set { if (!string.IsNullOrEmpty(value)) _codigo = value.ToUpper(); }
        }

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string Descricao
        {
            get { return _descricao; }
            set { if (!string.IsNullOrEmpty(value)) _descricao = value; }
        }

        public double Custo
        {
            get { return _custo; }
            set { if (value >= 0) _custo = value; }
        }

        public Veiculo Veiculo
        {
            get { return _veiculo; }
            set { if (value != null) _veiculo = value; }
        }

        public Manutencao(string codigo, DateTime data, string descricao, double custo, Veiculo veiculo)
        {
            Codigo = codigo;
            Data = data;
            Descricao = descricao;
            Custo = custo;
            Veiculo = veiculo;
        }

        public string ObterCodigo() => Codigo;

        public string MostrarDados()
            => $"Código: {Codigo} | Data: {Data:dd/MM/yyyy} | Descrição: {Descricao} | " +
               $"Custo: {Custo:F2} kz | Veículo: {Veiculo.Matricula}";
    }
}
