namespace Aulas.NET.Aula01
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExemploTipoPorValor();
            ExemploTipoPorReferencia();
        }

        class TipoPorRef
        {
            public int Codigo { get; set; }
        }

        private static void ExemploTipoPorReferencia()
        {
            Console.WriteLine("----- Exemplo tipo por referência -----");

            TipoPorRef valorInicial = new TipoPorRef
            {
                Codigo = new Random().Next(5, 20)
            };
            Console.WriteLine($"Valor Inicial: {valorInicial.Codigo}");

            MetodoTipoPorRef(valorInicial);
            Console.WriteLine($"Valor final alterado: {valorInicial.Codigo}\n");
        }

        private static void MetodoTipoPorRef(TipoPorRef tipoRef)
        {
            tipoRef.Codigo += new Random().Next(10, 30);
        }

        static void ExemploTipoPorValor()
        {
            Console.WriteLine("----- Exemplo tipo por valor -----");

            int valorIni = new Random().Next(5, 20);
            Console.WriteLine($"Valor inicial: {valorIni}");

            int valorAlterado = MetodoTipoPorValor(valorIni);

            Console.WriteLine($"Valor pós alteração: {valorAlterado}");
            Console.WriteLine($"Valor final: {valorIni}\n");
        }

        private static int MetodoTipoPorValor(int valorIni)
        {
            valorIni += new Random().Next(10, 30);
            return valorIni;
        }
    }
}
