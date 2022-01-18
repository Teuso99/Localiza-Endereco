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

        public async Task<Endereco> GetEnderecoByCep(string cep)
        {
            var client = new RestClient(ClientUrl);

            cep = cep.Trim().Replace(".", string.Empty).Replace("-", string.Empty);

            var requestUrl = ClientUrlRequest + cep + ResponseFormat;

            var request = new RestRequest(requestUrl, Method.Get);

            var response = await client.ExecuteGetAsync(request);

            var jObject = JObject.Parse(response.Content);

            if (jObject == null)
            {
                return null;
            }

            var endereco = new Endereco();
            JToken? token;

            endereco.CEP = jObject.TryGetValue("cep", out token) ? token.ToString() : null;
            endereco.Logradouro = jObject.TryGetValue("logradouro", out token) ? token.ToString() : null;
            endereco.Complemento = jObject.TryGetValue("complemento", out token) ? token.ToString() : null;
            endereco.Bairro = jObject.TryGetValue("bairro", out token) ? token.ToString() : null;
            endereco.Localidade = jObject.TryGetValue("localidade", out token) ? token.ToString() : null;
            endereco.UF = jObject.TryGetValue("uf", out token) ? token.ToString() : null;

            return endereco;
        }

        public async Task<List<Endereco>> GetEnderecosBySearch(string uf, string cidade, string logradouro)
        {

            if (string.IsNullOrWhiteSpace(uf) || string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(logradouro))
            {
                return null;
            }

            var client = new RestClient(ClientUrl);
            
            uf = uf + $"/";
            cidade = cidade + $"/";
            logradouro = logradouro + $"/";

            var requestUrl = ClientUrlRequest + uf + cidade + logradouro + ResponseFormat;

            var request = new RestRequest(requestUrl, Method.Get);

            var response = await client.ExecuteGetAsync(request);

            var jArray = JArray.Parse(response.Content);

            if (jArray == null)
            {
                return null;
            }

            var enderecoList = new List<Endereco>();

            foreach (var item in jArray)
            {
                if (item != null)
                {
                    Endereco endereco = item.ToObject<Endereco>();
                    enderecoList.Add(endereco);
                }
            }

            return await Task.FromResult(enderecoList);
        }
    }
}
