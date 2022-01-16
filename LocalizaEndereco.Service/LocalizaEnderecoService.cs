using Newtonsoft.Json.Linq;
using RestSharp;

namespace LocalizaEndereco.Service
{
    public class LocalizaEnderecoService
    {
        public string ClientUrl { get; set; }
        public string ClientUrlRequest { get; set; }
        public string ResponseFormat { get; set; }

        public LocalizaEnderecoService()
        {
            ClientUrl = "http://viacep.com.br/";
            ClientUrlRequest = "ws/";
            ResponseFormat = "/json/";
        }

        public async Task<Endereco> GetEndereco(string cep)
        {
            var client = new RestClient(ClientUrl);

            cep = cep.Trim().Replace(".", string.Empty).Replace("-", string.Empty);

            var requestUrl = ClientUrlRequest + cep + ResponseFormat;

            var request = new RestRequest(requestUrl, Method.Get);

            //request.AddHeader("Connection", "close");

            var response = await client.ExecuteGetAsync(request);

            var jObject = JObject.Parse(response.Content);

            var endereco = new Endereco();

            if (jObject == null)
            {
                return null;
            }

            JToken? token;

            endereco.CEP = jObject.TryGetValue("cep", out token) ? token.ToString() : null;
            endereco.Logradouro = jObject.TryGetValue("logradouro", out token) ? token.ToString() : null;
            endereco.Complemento = jObject.TryGetValue("complemento", out token) ? token.ToString() : null;
            endereco.Bairro = jObject.TryGetValue("bairro", out token) ? token.ToString() : null;
            endereco.Cidade = jObject.TryGetValue("localidade", out token) ? token.ToString() : null;
            endereco.UF = jObject.TryGetValue("uf", out token) ? token.ToString() : null;

            return endereco;
        }
    }
}
