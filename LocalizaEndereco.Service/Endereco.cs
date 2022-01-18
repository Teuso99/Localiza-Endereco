namespace LocalizaEndereco.Service
{
    public class Endereco
    {
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Localidade { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }

        public static implicit operator string(Endereco endereco)
        {
            endereco.Logradouro = string.IsNullOrWhiteSpace(endereco.Logradouro) ? "N/D" : endereco.Logradouro;
            endereco.Complemento = string.IsNullOrWhiteSpace(endereco.Complemento) ? "N/D" : endereco.Complemento;
            endereco.Bairro = string.IsNullOrWhiteSpace(endereco.Bairro) ? "N/D" : endereco.Bairro;
            endereco.Localidade = string.IsNullOrWhiteSpace(endereco.Localidade) ? "N/D" : endereco.Localidade;
            endereco.UF = string.IsNullOrWhiteSpace(endereco.UF) ? "N/D" : endereco.UF;
            endereco.CEP = string.IsNullOrWhiteSpace(endereco.CEP) ? "N/D" : endereco.CEP;

            return $"{endereco.Logradouro}, {endereco.Complemento}, {endereco.Bairro}. {endereco.Localidade} - {endereco.UF}. CEP: {endereco.CEP}";
        }
    }
}
