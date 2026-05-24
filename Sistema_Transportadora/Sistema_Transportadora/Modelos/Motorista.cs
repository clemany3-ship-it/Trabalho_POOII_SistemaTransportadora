using Sistema_Transportadora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Modelos
{
    public class Motorista:IRejistavel
    {
        private string nome;
        private string num_cartta;
        private string categoria_carta;
        private bool estado_activo;


        public string Nome
        {
            get {  return nome; }
            set {  
                if(!string.IsNullOrEmpty(value))
                    nome = value;

            }
        }

        public string Num_Carta
        {
            get { return num_cartta; }
            set {
                if(!string.IsNullOrEmpty(value))
                    num_cartta = value.ToUpper(); 
            
            }
        }
        public string Carta_categoria
        {
            get { return categoria_carta; }
            set { categoria_carta = value.ToUpper(); }
        }
        public bool Estado_activo
        {
            get { return estado_activo; }
            set { estado_activo = value; }
        }

        public Motorista(string _nome, string _numero_Carta,string  _carta_categoria) {
        
        nome = _nome;
        num_cartta = _numero_Carta.ToUpper();
        categoria_carta = _carta_categoria.ToUpper();
        estado_activo = true;
               
        }

        public string Obter_codigo()
        {
            return Num_Carta;
        }

        public string Mostra_dadoss()
        {
            return $"Nome :{Nome} | Numero da conta: {Num_Carta} | Categroria:{Carta_categoria} | Activo {Estado_activo}";
        }
    }
}
