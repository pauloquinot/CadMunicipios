using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = FazAlgumaCoisa(); // Assincrona
            // FazAlgumaCoisa().Wait() // Sincrona
            Soma(3, 4);
            Multiplica(5, 6);

            Console.Read();
        }

        private static async Task FazAlgumaCoisa()
        {
            Console.WriteLine("Começando a fazer alguma coisa. Esperando 10s.....");
            await Task.Delay(10000);
            Console.WriteLine("Pronto... Alguma coisa feita.");
        }
        private static void Soma(int num1, int num2)
        {
            Console.WriteLine("O resultado da soma é: {0}", num1 + num2);
        }
        private static void Multiplica(int num1, int num2)
        {
            Console.WriteLine("O resultado da multiplicação é: {0}", num1 * num2);
        }
    }
}
