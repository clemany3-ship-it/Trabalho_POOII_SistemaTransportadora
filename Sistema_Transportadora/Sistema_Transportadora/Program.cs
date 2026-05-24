using Sistema_Transportadora.Modelos;
using Sistema_Transportadora.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Transportadora
{
    class Program {

        
        // instanciar os serviços para usar em todos o programma
        private static VeiculoService _veiculoService =
            new VeiculoService();
        private static MotoristaService _motoristaServico = new
            MotoristaService();
        private static RotaServico _rotaServico = new RotaServico();
        private static ViagemService _viagemService = new ViagemService();

        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("(1) Adicionar Veiculo");
                Console.WriteLine("(2) Lista Todos Veiculos");
                Console.WriteLine("(3) Adicionar Motorista");
                Console.WriteLine("(4) Lista todos os Motoristas");
                Console.WriteLine("(5) Adicionar Rotas");
                Console.WriteLine("(6) Lista Todas Rotas");
                Console.WriteLine("(7  Registar Novas Viagem)");
                Console.WriteLine("(8) Lista todas as Viagem");
                Console.WriteLine("(0) Sari");
                Console.WriteLine("(Escolhe uma Opção: )");

                try{
                    int opcao=0;
                    opcao = Convert.ToInt32(Console.ReadLine());


                    switch (opcao)
                    {

                        case 1: AdicionarVeicuolo(); break;
                        case 2: ListaVeicular(); break;
                        case 3: AdicionarMotorista(); break;
                        case 4: ListarMotorista(); break;
                        case 5: AdicionarRotas(); break;
                        case 6: ListaRotas(); break;
                        case 7: RegistarNovasViagem(); break;
                        case 8: ListaTodasViagem(); break;
                        case 0: return;
                        default:
                            Console.WriteLine("Opção invalida"); break;
                    }
                }
                catch (FormatException)

                {
                    Console.WriteLine("Erro.Digita  só apenas Numero");
                }
                catch (Exception ex) {

                    Console.WriteLine($"Erro: {ex.Message}");

                }
                Console.WriteLine("\n Carrega Em qualquer Tecla para Continuar ..."); Console.ReadKey();

            }

        }

        #region Métodos Veiculos
        //AdicionarVeicuolo();
        private static void AdicionarVeicuolo()
        {
            Console.WriteLine("\n\n ---- ADICIONAR VEICULO ---");
            Console.WriteLine("Matricula: ");
            string matricula = Console.ReadLine();

            Console.WriteLine("Tipo: 1-Ligeiro 2- Pesado 3-Passageiro 4-Mercadoria 5- Especial ");
            Console.WriteLine("Escolhe");
            Tipo_Veiculo tipo = (Tipo_Veiculo)Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("Capacidade ed Cargo(Kg): ");
            int carga = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Consumo por Km: ");
            double consumo = Convert.ToDouble(Console.ReadLine());

            Veiculo novo = new Veiculo(matricula,tipo,carga,consumo);

            _veiculoService.AdicionarVeiculo(novo);
            Console.WriteLine("Veioculo  Adicionado com Sucesso");

        }

        //Lista os veiculos

        private static void ListaVeicular()
        {
            Console.WriteLine("\n\n----- LISTA DE VEICULO----");
            var lista = _veiculoService.ListarTodos();
            if (lista.Count == 0) {

                Console.WriteLine("Nenhum Motorista Registado.");
                return;

            }
            foreach (var v in lista)
            {
                Console.WriteLine(v.Mostra_dadoss());
            }
        }
        #endregion.
        #region Métodos Motoorista
        private static void AdicionarMotorista()
        {
            Console.WriteLine("\n---- ADICIONR MOTRISTA---");
            Console.WriteLine("Nome Completo; ");
            string nome = Console.ReadLine();
            Console.Write("Numero da Carta: ");
            string carta = Console.ReadLine();
            Console.Write("Categoria da Carta: ");
            string categoria = Console.ReadLine();
            Motorista novo = new Motorista(nome, carta, categoria);
            _motoristaServico.AdicionarMotorista(novo);
            Console.WriteLine("Motorista Addicionado com sucesso");
        }
        //-Lista motorista
        private static void ListarMotorista()
        {

            Console.WriteLine(" n\\n LISTAR MOTORISTAS");
            var lista = _motoristaServico.ListarTodos();
            if (lista.Count == 0) {
                Console.WriteLine("Nenhum Motoirsta registado");
                return;
            }
            foreach (var m in lista)
            {
                Console.WriteLine(m.Mostra_dadoss());
            }
        }
        #endregion.
        #region Métodos Rotas
        private static void AdicionarRotas()
        {
            Console.WriteLine("\n---- ADICIONR ROTA---");
            Console.WriteLine("Codigo da Rota ; ");
            string codigo = Console.ReadLine();
            Console.Write("Origem: ");
            string origem = Console.ReadLine();
            Console.Write(" Destino: ");
            string destino = Console.ReadLine();
            Console.Write(" Destancia em km: ");
            double destancia = Convert.ToDouble(Console.ReadLine());

            Rota novo = new Rota(codigo, origem, destino, destancia);

            _rotaServico.AdicionarRota(novo);

            Console.WriteLine("Motorista Addicionado com sucesso");

        }
        // Lista as rotas 
        private static void ListaRotas()
        {

            Console.WriteLine(" n\\n LISTAR AS ROTAS");
            var lista = _rotaServico.ListarTodos();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma rota registado");
                return;
            }
            foreach (var r in lista)
            {
                Console.WriteLine(r.Mostra_dadoss());
            }

        }

        #endregion.
        #region Métodos Viagem

        private static void RegistarNovasViagem()
        {
            Console.WriteLine("\n---- ADICIONR VIAGEM---");
            Console.WriteLine("Codigo DE VIAGEM: ");
            string codigo = Console.ReadLine();
            Console.Write(" Matricula do veiculo: ");
            string mtricula = Console.ReadLine().ToUpper();
           
            Veiculo veiculo = _veiculoService.ProcurarPorMatricula(mtricula);

            Console.Write(" Numero da Carta do mootrista: ");
            string carta = Console.ReadLine();

            Motorista motorista = _motoristaServico.ProcurarPorCarta(carta);
            Console.Write("Codigo da Rota");
            string CodRota = Console.ReadLine();
            Rota rota = _rotaServico.ProcurarPorCodigo(CodRota);


            Viagem nova = new Viagem(codigo,DateTime.Now,veiculo,motorista, rota);

           

            try
            {
                _viagemService.RegistarViagem(nova);
                Console.WriteLine(" Viagem Registada com Sucesso");
            }
            catch (VeiculoIndisponivelException ex)
            {
                Console.WriteLine($"Aviso:{ex.Message}");
            }
            catch (MotoristaInabilitadoException ex)
            {
                Console.WriteLine($"Aviso: {ex.Message}");
            }
            catch (Rota_N_esxisteException ex) {

                Console.WriteLine($"Aviso: {ex.Message}");
            }
        }
        // listar viagem
        private static void ListaTodasViagem()
        {
            Console.WriteLine("\n--- LISTA DE VIAGEM");
            var lista = _viagemService.ListarTodas();
            if (lista.Count == 0) {
                Console.WriteLine("Nenhuma viagem registada.");
                return;
            }
            foreach (var v in lista)
            {
                Console.WriteLine(v.Mostra_dadoss());
            }

        }

        #endregion.
    }
}
