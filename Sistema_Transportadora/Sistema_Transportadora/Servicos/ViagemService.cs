using Sistema_Transportadora.Interface;
using Sistema_Transportadora.Modelos;
using Sistema_Transportadora.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora.Servicos
{
    public class ViagemService
    {

        private readonly ViagemRepository _repositor;
        private readonly VeiculoService _veiculoService;
        private readonly MotoristaService _motoristaService;
        private readonly RotaServico _rotaServico;

        public ViagemService()
        {
            _repositor = new ViagemRepository();
            _veiculoService = new VeiculoService();
            _motoristaService = new MotoristaService();
            _rotaServico = new RotaServico();
        }
        public void RegistarViagem(Viagem viagem)
        {
            if (viagem == null)
                throw new ArgumentNullException("Dados da viagem não podem ser vazio");


            // validação e uso das exceção
            var veiculo = _veiculoService.ProcurarPorMatricula(viagem.VeiculoUsado.Matricula);
            if (veiculo.Estado != Estado_Veiculo.Disponivel)
                throw new VeiculoIndisponivelException();
            var motorista=_motoristaService.ProcurarPorCarta(viagem.Motorista_R.Num_Carta);
            if(!motorista.Estado_activo)
                throw new MotoristaInabilitadoException();
            var rota = _rotaServico.ProcurarPorCodigo(viagem.Rotaescolhida.Codigorota);
            // Se tudo certo,guarde e muda o estudo do veiculo

            _repositor.Adicionar(viagem);
            veiculo.Estado=Estado_Veiculo.Em_viagem;
        }
        public List<Viagem> ListarTodas()
        {
            return _repositor.ObterTodos();
        }


        /**/

    }
}
/*
 

        private readonly ViagemRepository _repositor;
        private readonly VeiculoService _veiculoService;
        private readonly MotoristaService _motoristaService;
        private readonly RotaServico _rotaServico;

        public ViagemService()
        {
            _repositor = new ViagemRepository();
            _veiculoService = new VeiculoService();
            _motoristaService = new MotoristaService();
            _rotaServico = new RotaServico();
        }
        public void RegistarViagem(Viagem viagem)
        {
            if (viagem == null)
                throw new ArgumentNullException("Dados da viagem não podem ser vazio");


            // validação e uso das exceção
            var veiculo = _veiculoService.ProcurarPorMatricula(viagem.VeiculoUsado.Matricula);
            if (veiculo.Estado != Estado_Veiculo.Disponivel)
                throw new VeiculoIndisponivelException();
            var motorista=_motoristaService.ProcurarPorCarta(viagem.Motorista_R.Num_Carta);
            if(!motorista.Estado_activo)
                throw new MotoristaInabilitadoException();
            var rota = _rotaServico.ProcurarPorCodigo(viagem.Rotaescolhida.Codigorota);
            // Se tudo certo,guarde e muda o estudo do veiculo


 
 
 
 */