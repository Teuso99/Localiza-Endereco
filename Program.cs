using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Web;

namespace LocalizaEndereco
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://buscacepinter.correios.com.br");

            Console.WriteLine("Informe o CEP (apenas números)");
            var cep = Console.ReadLine();

            string param = "endereco=" + cep + "&tipoCEP=ALL";

            var request = new RestRequest("/app/endereco/carrega-cep-endereco.php?" + param, DataFormat.Json);

            var response = client.Get(request);

            var jObject = JObject.Parse(response.Content);

            string rua = (string)jObject.SelectToken("dados[0].logradouroDNEC");
            string bairro = (string)jObject.SelectToken("dados[0].bairro");
            string cidade = (string)jObject.SelectToken("dados[0].localidade");
            string estado = (string)jObject.SelectToken("dados[0].uf");

            string resultado = rua + ", " + bairro + ", " + cidade + ", " + estado;

            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Endereço: " + resultado);
            Console.WriteLine("------------------------------------------------------------");
        }
    }
}
