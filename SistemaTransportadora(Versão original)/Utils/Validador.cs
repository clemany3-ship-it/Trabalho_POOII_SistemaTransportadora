using System;

namespace SistemaTransportadora.Utils
{
    public static class Validador
    {
        public static int LerInteiroPositivo(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
                    return valor;
                Console.WriteLine("  [Erro] Introduza um número inteiro positivo.");
            }
        }

        public static double LerDoublePositivo(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
                    return valor;
                Console.WriteLine("  [Erro] Introduza um número decimal positivo.");
            }
        }

        public static string LerTextoObrigatorio(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string valor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(valor))
                    return valor.Trim();
                Console.WriteLine("  [Erro] Campo obrigatório. Tente novamente.");
            }
        }

        public static DateTime LerData(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem + " (dd/MM/yyyy HH:mm): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime data))
                    return data;
                Console.WriteLine("  [Erro] Formato inválido. Use dd/MM/yyyy HH:mm (ex: 25/05/2026 08:30).");
            }
        }
    }
}
