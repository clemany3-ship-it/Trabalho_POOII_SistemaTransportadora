using SistemaTransportadora.Interfaces;

namespace SistemaTransportadora.Models
{
    public class Motorista : IRegistavel
    {
        private string _nome;
        private string _numeroCarta;
        private string _categoriaCarta;
        private bool _estadoActivo;

        public string Nome
        {
            get { return _nome; }
            set { if (!string.IsNullOrEmpty(value)) _nome = value; }
        }

        public string NumeroCarta
        {
            get { return _numeroCarta; }
            set { if (!string.IsNullOrEmpty(value)) _numeroCarta = value.ToUpper(); }
        }

        public string CategoriaCarta
        {
            get { return _categoriaCarta; }
            set { if (!string.IsNullOrEmpty(value)) _categoriaCarta = value.ToUpper(); }
        }

        public bool EstadoActivo
        {
            get { return _estadoActivo; }
            set { _estadoActivo = value; }
        }

        public Motorista(string nome, string numeroCarta, string categoriaCarta)
        {
            Nome = nome;
            NumeroCarta = numeroCarta;
            CategoriaCarta = categoriaCarta;
            _estadoActivo = true;
        }

        public string ObterCodigo() => NumeroCarta;

        public string MostrarDados()
            => $"Nome: {Nome} | Carta: {NumeroCarta} | Categoria: {CategoriaCarta} | Activo: {EstadoActivo}";
    }
}
