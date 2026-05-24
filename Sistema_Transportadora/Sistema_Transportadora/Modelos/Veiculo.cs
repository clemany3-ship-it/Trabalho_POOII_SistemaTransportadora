using Sistema_Transportadora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Modelos
{
    public class Veiculo:IRejistavel
    {
        private string _matricula;
        private Tipo_Veiculo _tipo;
        private int _capacidadeCarga;
        private Estado_Veiculo _estado;
        private double _consumoPorKkm;

        public string Matricula {
            get { return _matricula; }
            set { _matricula = value.ToUpper(); }
        
        }
        public Tipo_Veiculo Tipo
        {
            get { return _tipo; }
            set { _tipo= value; }
        }

        public int Capacidade
        {
            get {return _capacidadeCarga; }
            set { _capacidadeCarga= value; }
        }
        public Estado_Veiculo Estado
        {
            get { return _estado; }
            set {  _estado = value; }
        }

        public double ConsumoPorKm
        {
            get { return _consumoPorKkm; }
            set { 
                if(value >=0)
                    _consumoPorKkm = value;


            }
        }

        public Veiculo(string matricula, Tipo_Veiculo tipo, int capacidadecarga,double consumo)
        {
            _matricula= matricula;
            _tipo= tipo;
            _capacidadeCarga= capacidadecarga;
            _consumoPorKkm= consumo;
            _estado = Estado_Veiculo.Disponivel;
        }

        // Metodo da interface
        public string Obter_codigo()
        {
            return Matricula;
        }

        public string Mostra_dadoss()
        {
            return $"Matricula: {Matricula} | Tipo: {Tipo} | Capacidade: { Capacidade} kg | Estado: {Estado}";
        }


    }


}
