using Sistema_Transportadora.Modelos;
using Sistema_Transportadora.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Servicos
{
    public class MotoristaService
    {
        private readonly MotoristaRepositoy _repositor;
        public MotoristaService()
        {
            _repositor = new MotoristaRepositoy();

        }
        public void AdicionarMotorista(Motorista motorista){

            if (motorista == null) 
                throw new ArgumentNullException("Dados do motorista não pode ser vazios");          
            
            _repositor.Adicionar(motorista);

            }

        public Motorista ProcurarPorCarta(string numeroCarta)
        {
            if (numeroCarta == null) 
                throw new ArgumentNullException("Numero da carta invalido");

             var motorista=_repositor.ObterPorCodigo(numeroCarta);
            if (motorista == null)
                throw new Exception("Motorista não encontrado");
            return motorista;
        }
        public List<Motorista> ListarTodos() {

            return _repositor.ObterTodos();
        
        
        }

        public void DesativarMotorista(string numeroCarta)
        {
            var motorista = ProcurarPorCarta(numeroCarta);
            motorista.Estado_activo = false;
        }




    }
}
