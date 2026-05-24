using Sistema_Transportadora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Sistema_Transportadora.Modelos
{
    public class Viagem:IRejistavel
    {
        private string codigo_viagem;
        private DateTime data_viagem;
        private Veiculo veioculo_Usado;
        private Motorista motorista_responsavel;
        private Rota rota_escoolhida;
        private double custo_total;

        public string Codigo_viagem
        {
            get { return codigo_viagem; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    codigo_viagem = value.ToUpper();
            }
        }
        public DateTime Data_vagem {
            get { return data_viagem; }
            set { data_viagem = value; }

        }
        public Veiculo VeiculoUsado
        {
            get { return veioculo_Usado; }
            set
            {
                if (value != null)
                    veioculo_Usado = value;
            }
        }

        public Motorista Motorista_R
        {
            get { return motorista_responsavel; }
            set { motorista_responsavel = value; }

        }
        public Rota Rotaescolhida
        {
            get { return  rota_escoolhida; }
            set {if (value != null)
                    rota_escoolhida = value;
                        }
        }

        public double CustoTotal{
            get { return custo_total; }
            set { if (value >= 0)
                    custo_total = value;

            }
        }
    
        public Viagem(string _codigoViagem, DateTime _dataV, Veiculo _veicuoV, Motorista _MotoristaV ,Rota _rotaV) { 
        

            codigo_viagem = _codigoViagem.ToUpper();
            data_viagem = _dataV;
            veioculo_Usado = _veicuoV;
            motorista_responsavel = _MotoristaV;
            rota_escoolhida= _rotaV;
            custo_total = _rotaV.Distancia_km * _veicuoV.ConsumoPorKm;

        }
        
        public string Obter_codigo() {

            return Codigo_viagem;
        }

        public string Mostra_dadoss()
        {
            return $" Codigo de Viagem {Codigo_viagem} | Data da viagem {Data_vagem} | Veiculo {VeiculoUsado} | Motorista Responsavel {Motorista_R} | Rota escolhida {Rotaescolhida} |Custo total {CustoTotal} ";
        }

    }
}
