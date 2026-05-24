using Sistema_Transportadora.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Modelos
{
    public class Rota:IRejistavel
    {
        private string codigoRot;
        private string origem;
        private string destino;
        private double distanciaKm;

        public string Codigorota
        {
            get { return codigoRot; }
            set { 
                if (string.IsNullOrEmpty(value))
                  codigoRot = value.ToUpper(); }
            

        }
        public string Origem
        {
            get { return origem; }
            set
            {
                if (string.IsNullOrEmpty(value))
                     origem = value;
            }
        }
        public string Destino
        {
            get { return destino; }
            set { if (string.IsNullOrEmpty(value)) 
                    destino = value; }
        }

        public double Distancia_km
        {
            get { return distanciaKm; }
            set { distanciaKm = value; }
        }

        public Rota(string _codigo,string _origem, string _destino, double distancia)
        {
            codigoRot= _codigo;
            origem= _origem;
            destino= _destino;
            Distancia_km = distanciaKm;
        }
        public string Obter_codigo()
        {
            return Codigorota;
        }
        public string Mostra_dadoss() {

            return $" Codigo: {Codigorota} | Origem {Origem} | Destino {Destino} | Distancia por KM: {Distancia_km}KM .";
        
        
        }
    }
}