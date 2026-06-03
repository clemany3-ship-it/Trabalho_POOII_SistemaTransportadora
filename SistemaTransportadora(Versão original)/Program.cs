using SistemaTransportadora.Exceptions;
using SistemaTransportadora.Models;
using SistemaTransportadora.Services;
using SistemaTransportadora.Utils;
using System;

namespace SistemaTransportadora
{
    class Program
    {
        private static VeiculoService _veiculoService = new VeiculoService();
        private static MotoristaService _motoristaService = new MotoristaService();
        private static RotaService _rotaService = new RotaService();
        private static ViagemService _viagemService;

        static void Main(string[] args)
        {
            _viagemService = new ViagemService(_veiculoService, _motoristaService, _rotaService);

            while (true)
            {
                
                Console.Clear();
                Console.WriteLine(".........══════════════════════════════........");
                Console.WriteLine("|     SISTEMA DE GESTÃO DE TRANSPORTADORA      |");
                Console.WriteLine("|______________________________________________|");
                Console.WriteLine("|  VEÍCULOS                                    |");
                Console.WriteLine("|   (1) Adicionar Veículo                      |");
                Console.WriteLine("|   (2) Listar Veículos                        |");
                Console.WriteLine("|   (3) Remover Veículo                        |");
                Console.WriteLine("|..............................................|");
                Console.WriteLine("|  MOTORISTAS                                  |");
                Console.WriteLine("|   (4) Adicionar Motorista                    |");
                Console.WriteLine("|   (5) Listar Motoristas                      |");
                Console.WriteLine("|   (6) Remover Motorista                      |");
                Console.WriteLine("|   (7) Activar / Desactivar Motorista         |");
                Console.WriteLine("|..............................................|");
                Console.WriteLine("|  ROTAS                                       |");
                Console.WriteLine("|   (8) Adicionar Rota                         |");
                Console.WriteLine("|   (9) Listar Rotas                           |");
                Console.WriteLine("|  (10) Remover Rota                           |");
                Console.WriteLine("|..............................................|");
                Console.WriteLine("|  VIAGENS                                     |");
                Console.WriteLine("|  (11) Agendar Viagem                         |");
                Console.WriteLine("|  (12) Iniciar Viagem                         |");
                Console.WriteLine("|  (13) Concluir Viagem                        |");
                Console.WriteLine("|  (14) Cancelar Viagem                        |");
                Console.WriteLine("|  (15) Listar Todas as Viagens                |");
                Console.WriteLine("|  (16) Listar Viagens Agendadas               |");
                Console.WriteLine("|..............................................|");
                Console.WriteLine("|   (0) Sair                                   |");
                Console.WriteLine(" ---------------------------------------------- ");
                Console.Write("\n  Escolhe uma opção: ");

                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int opcao))
                        throw new FormatException();

                    switch (opcao)
                    {
                        case 1:  AdicionarVeiculo();           break;
                        case 2:  ListarVeiculos();             break;
                        case 3:  RemoverVeiculo();             break;
                        case 4:  AdicionarMotorista();         break;
                        case 5:  ListarMotoristas();           break;
                        case 6:  RemoverMotorista();           break;
                        case 7:  ToggleMotorista();            break;
                        case 8:  AdicionarRota();              break;
                        case 9:  ListarRotas();                break;
                        case 10: RemoverRota();                break;
                        case 11: AgendarViagem();              break;
                        case 12: IniciarViagem();              break;
                        case 13: ConcluirViagem();             break;
                        case 14: CancelarViagem();             break;
                        case 15: ListarViagens();              break;
                        case 16: ListarViagensAgendadas();     break;
                        case 0:
                            Console.WriteLine("\n  Até logo! (o veículo já foi estacionado) ");
                            return;
                        default:
                            Console.WriteLine("  [Erro] Opção inválida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("  [Erro] Introduz apenas um número.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"  [Aviso] {ex.Message}");
                }

                Console.WriteLine("\n  Pressiona qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        #region Veículos

        static void AdicionarVeiculo()
        {
            Console.WriteLine("\n  ── ADICIONAR VEÍCULO ──");
            string matricula = Validador.LerTextoObrigatorio("  Matrícula: ");
            Console.WriteLine("  Tipo: 1-Ligeiro  2-Pesado  3-Passageiros  4-Mercadorias  5-Especial");
            int tipoInt = Validador.LerInteiroPositivo("  Escolha o tipo: ");
            if (tipoInt < 1 || tipoInt > 5) throw new Exception("Tipo de veículo inválido (1-5).");
            TipoVeiculo tipo = (TipoVeiculo)(tipoInt - 1);
            int capacidade = Validador.LerInteiroPositivo("  Capacidade de carga (kg): ");
            double consumo = Validador.LerDoublePositivo("  Consumo por km (L/km): ");

            _veiculoService.Adicionar(new Veiculo(matricula, tipo, capacidade, consumo));
            Console.WriteLine("  [OK] Veículo adicionado com sucesso!");
        }

        static void ListarVeiculos()
        {
            Console.WriteLine("\n  ── LISTA DE VEÍCULOS ──");
            var lista = _veiculoService.ListarTodos();
            if (lista.Count == 0) { Console.WriteLine("  Nenhum veículo registado."); return; }
            foreach (var v in lista)
                Console.WriteLine("  " + v.MostrarDados());
        }

        static void RemoverVeiculo()
        {
            Console.WriteLine("\n  ── REMOVER VEÍCULO ──");
            string matricula = Validador.LerTextoObrigatorio("  Matrícula a remover: ");
            _veiculoService.Remover(matricula);
            Console.WriteLine("  [OK] Veículo removido com sucesso!");
        }

        #endregion

        #region Motoristas

        static void AdicionarMotorista()
        {
            Console.WriteLine("\n  ── ADICIONAR MOTORISTA ──");
            string nome = Validador.LerTextoObrigatorio("  Nome completo: ");
            string carta = Validador.LerTextoObrigatorio("  Número da carta: ");
            string categoria = Validador.LerTextoObrigatorio("  Categoria da carta (ex: B, C): ");

            _motoristaService.Adicionar(new Motorista(nome, carta, categoria));
            Console.WriteLine("  [OK] Motorista adicionado com sucesso!");
        }

        static void ListarMotoristas()
        {
            Console.WriteLine("\n  ── LISTA DE MOTORISTAS ──");
            var lista = _motoristaService.ListarTodos();
            if (lista.Count == 0) { Console.WriteLine("  Nenhum motorista registado."); return; }
            foreach (var m in lista)
                Console.WriteLine("  " + m.MostrarDados());
        }

        static void RemoverMotorista()
        {
            Console.WriteLine("\n  ── REMOVER MOTORISTA ──");
            string carta = Validador.LerTextoObrigatorio("  Número de carta a remover: ");
            _motoristaService.Remover(carta);
            Console.WriteLine("  [OK] Motorista removido com sucesso!");
        }

        static void ToggleMotorista()
        {
            Console.WriteLine("\n  ── ACTIVAR / DESACTIVAR MOTORISTA ──");
            string carta = Validador.LerTextoObrigatorio("  Número de carta: ");
            var m = _motoristaService.ObterPorCarta(carta);
            if (m.EstadoActivo)
            {
                _motoristaService.Desativar(carta);
                Console.WriteLine("  [OK] Motorista desactivado.");
            }
            else
            {
                _motoristaService.Ativar(carta);
                Console.WriteLine("  [OK] Motorista activado.");
            }
        }

        #endregion

        #region Rotas

        static void AdicionarRota()
        {
            Console.WriteLine("\n  ── ADICIONAR ROTA ──");
            string codigo = Validador.LerTextoObrigatorio("  Código da rota: ");
            string origem = Validador.LerTextoObrigatorio("  Origem: ");
            string destino = Validador.LerTextoObrigatorio("  Destino: ");
            double distancia = Validador.LerDoublePositivo("  Distância (km): ");

            _rotaService.Adicionar(new Rota(codigo, origem, destino, distancia));
            Console.WriteLine("  [OK] Rota adicionada com sucesso!");
        }

        static void ListarRotas()
        {
            Console.WriteLine("\n  ── LISTA DE ROTAS ──");
            var lista = _rotaService.ListarTodos();
            if (lista.Count == 0) { Console.WriteLine("  Nenhuma rota registada."); return; }
            foreach (var r in lista)
                Console.WriteLine("  " + r.MostrarDados());
        }

        static void RemoverRota()
        {
            Console.WriteLine("\n  ── REMOVER ROTA ──");
            string codigo = Validador.LerTextoObrigatorio("  Código da rota a remover: ");
            _rotaService.Remover(codigo);
            Console.WriteLine("  [OK] Rota removida com sucesso!");
        }

        #endregion

        #region Viagens

        static void AgendarViagem()
        {
            Console.WriteLine("\n  ── AGENDAR VIAGEM ──");
            string codigo = Validador.LerTextoObrigatorio("  Código da viagem: ");
            DateTime data = Validador.LerData("  Data da viagem");
            string matricula = Validador.LerTextoObrigatorio("  Matrícula do veículo: ");
            string carta = Validador.LerTextoObrigatorio("  Número de carta do motorista: ");
            string codRota = Validador.LerTextoObrigatorio("  Código da rota: ");

            var veiculo = _veiculoService.ObterPorMatricula(matricula);
            var motorista = _motoristaService.ObterPorCarta(carta);
            var rota = _rotaService.ObterPorCodigo(codRota);

            var viagem = new Viagem(codigo, data, veiculo, motorista, rota);
            _viagemService.Agendar(viagem);
            Console.WriteLine($"  [OK] Viagem agendada! Custo estimado: {viagem.CustoTotal:F2} kz");
        }

        static void IniciarViagem()
        {
            Console.WriteLine("\n  ── INICIAR VIAGEM ──");
            string codigo = Validador.LerTextoObrigatorio("  Código da viagem: ");
            _viagemService.Iniciar(codigo);
            Console.WriteLine("  [OK] Viagem iniciada com sucesso!");
        }

        static void ConcluirViagem()
        {
            Console.WriteLine("\n  ── CONCLUIR VIAGEM ──");
            string codigo = Validador.LerTextoObrigatorio("  Código da viagem: ");
            _viagemService.Concluir(codigo);
            Console.WriteLine("  [OK] Viagem concluída! Veículo libertado.");
        }

        static void CancelarViagem()
        {
            Console.WriteLine("\n  ── CANCELAR VIAGEM ──");
            string codigo = Validador.LerTextoObrigatorio("  Código da viagem a cancelar: ");
            _viagemService.Cancelar(codigo);
            Console.WriteLine("  [OK] Viagem cancelada e removida. Veículo libertado.");
        }

        static void ListarViagens()
        {
            Console.WriteLine("\n  ── TODAS AS VIAGENS ──");
            var lista = _viagemService.ListarTodas();
            if (lista.Count == 0) { Console.WriteLine("  Nenhuma viagem registada."); return; }
            foreach (var v in lista)
                Console.WriteLine("  " + v.MostrarDados());
        }

        static void ListarViagensAgendadas()
        {
            Console.WriteLine("\n  ── VIAGENS AGENDADAS ──");
            var lista = _viagemService.ListarAgendadas();
            if (lista.Count == 0) { Console.WriteLine("  Nenhuma viagem agendada."); return; }
            foreach (var v in lista)
                Console.WriteLine("  " + v.MostrarDados());
        }

        #endregion
    }
}
