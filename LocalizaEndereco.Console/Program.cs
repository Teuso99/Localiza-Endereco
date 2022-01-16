using LocalizaEndereco.Service;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Informe o CEP (apenas números)");
        var cep = Console.ReadLine();

        var localizaEnderecoService = new LocalizaEnderecoService();

        try
        {
            var resultado = await localizaEnderecoService.GetEndereco(cep);

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Endereço: " + resultado);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
}