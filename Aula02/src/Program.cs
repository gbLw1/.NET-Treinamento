using static System.Console;

namespace Aulas.NET.Aula02
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            //var cliente = new Cliente("Everton", "Sette", 1000);
            Cliente cliente = new("Everton", "Sette", 1000);

            WriteLine($"Nome completo do cliente: {cliente.Nome} {cliente.Sobrenome}");
            WriteLine($"Limite de crédito: {cliente.Credito.ToString("N2")}");

            cliente.AjustarCredito(random.Next());
            WriteLine($"Limite de crédito: {cliente.Credito.ToString("N2")}");

            cliente.AjustarCredito(-1 * random.Next());
            WriteLine($"Limite de crédito: {cliente.Credito.ToString("N2")}");

            cliente.AjustarCredito(random.Next());
            WriteLine($"Limite de crédito: {cliente.Credito.ToString("N2")}");

            cliente.AjustarCredito(-1 * random.Next());
            WriteLine($"Limite de crédito: {cliente.Credito.ToString("N2")}");

            cliente.Credito = 1000;
            WriteLine($"Limite de crédito: {cliente.Credito.ToString("N2")}");

            ReadKey();
        }
    }
}
