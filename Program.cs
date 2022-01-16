using LocalizaEnderecoService;
using System;
using System.Threading.Tasks;

namespace LocalizaEndereco
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Informe o CEP (apenas números)");
            var cep = Console.ReadLine();

            var localizaEnderecoService = new LocalizaEnderecoService.LocalizaEnderecoService();

            try
            {
                var resultado = await localizaEnderecoService.GetEndereco(cep);

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("Endereço: " + resultado);
                Console.WriteLine("------------------------------------------------------------");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
