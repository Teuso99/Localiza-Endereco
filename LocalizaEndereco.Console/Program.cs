using LocalizaEndereco.Service;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Informe o CEP");
        var cep = Console.ReadLine();

        var localizaEnderecoService = new LocalizaEnderecoService();

        try
        {
            var resultado = await localizaEnderecoService.GetEnderecoByCep(cep);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Endereço: " + resultado);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("Informe a cidade");
        var cidade = Console.ReadLine();

        Console.WriteLine("Informe o logradouro");
        var logradouro = Console.ReadLine();

        Console.WriteLine("Informe a UF");
        var uf = Console.ReadLine();

        try
        {
            var resultado = await localizaEnderecoService.GetEnderecosBySearch(uf, cidade, logradouro);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Endereços: ");

            foreach (var item in resultado)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}