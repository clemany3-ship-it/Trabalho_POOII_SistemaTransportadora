using Sistema_Transportadora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Modelos
{
    internal class Manutencao:IRejistavel
    {
        private string codigomanutencao;
        private DateTime datamanutencao;
        private string descricaoServico;
        private double custoServico;
        private Veiculo veculloAlvo;

        public string CodManut
        {
            get { return codigomanutencao; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    codigomanutencao = value.ToUpper();
                }
            }
        }
        public DateTime DataManut
        {
            get => datamanutencao;
            set { datamanutencao = value; }
        }

        public string DescriSirvico
        {
            get => descricaoServico;
            set
            {
                if (!string.IsNullOrEmpty(value))

                { descricaoServico = value; }
            }
        }
        public double CuustoServico
        {
            get { return  custoServico;}
            set { if(value >=0)
                    custoServico = value;}
        }

        public Veiculo Veiculo
        {
            get { return veculloAlvo; }
            set { 
                if(veculloAlvo != null)
                veculloAlvo = value; }
        }
        

        public Manutencao(string _codigM,DateTime _dateM,string _descricaoServi,double _custoServ,Veiculo _veiAlvo)
        {
            codigomanutencao = _codigM;
            datamanutencao= _dateM;
            descricaoServico= _descricaoServi;
            custoServico= _custoServ;
            veculloAlvo = _veiAlvo;
        }

        public string Obter_codigo() {

            return CodManut;
        }

        public string Mostra_dadoss()
        {
            return $"Codigo de Manutenção {codigomanutencao} | Data de Manutençºao | DEscrição {DescriSirvico} | Custo Total {CuustoServico} | Veiculuo {Veiculo}";
        }

    }
}




