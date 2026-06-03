using SistemaTransportadora.Interfaces;

namespace SistemaTransportadora.Models
{
    public class Rota : IRegistavel
    {
        private string _codigo;
        private string _origem;
        private string _destino;
        private double _distanciaKm;

        public string Codigo
        {
            get { return _codigo; }
            set { if (!string.IsNullOrEmpty(value)) _codigo = value.ToUpper(); }
        }

        public string Origem
        {
            get { return _origem; }
            set { if (!string.IsNullOrEmpty(value)) _origem = value; }
        }

        public string Destino
        {
            get { return _destino; }
            set { if (!string.IsNullOrEmpty(value)) _destino = value; }
        }

        public double DistanciaKm
        {
            get { return _distanciaKm; }
            set { if (value > 0) _distanciaKm = value; }
        }

        public Rota(string codigo, string origem, string destino, double distancia)
        {
            Codigo = codigo;
            Origem = origem;
            Destino = destino;
            DistanciaKm = distancia;
        }

        public string ObterCodigo() => Codigo;

        public string MostrarDados()
            => $"Código: {Codigo} | Origem: {Origem} | Destino: {Destino} | Distância: {DistanciaKm} km";
    }
}
