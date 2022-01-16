namespace LocalizaEndereco.Service
{
    public class Endereco
    {
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }
        public string? CEP { get; set; }

        public static implicit operator string(Endereco endereco)
        {
            endereco.Logradouro = string.IsNullOrWhiteSpace(endereco.Logradouro) ? "N/D" : endereco.Logradouro;
            endereco.Complemento = string.IsNullOrWhiteSpace(endereco.Complemento) ? "N/D" : endereco.Complemento;
            endereco.Bairro = string.IsNullOrWhiteSpace(endereco.Bairro) ? "N/D" : endereco.Bairro;
            endereco.Cidade = string.IsNullOrWhiteSpace(endereco.Cidade) ? "N/D" : endereco.Cidade;
            endereco.UF = string.IsNullOrWhiteSpace(endereco.UF) ? "N/D" : endereco.UF;
            endereco.CEP = string.IsNullOrWhiteSpace(endereco.CEP) ? "N/D" : endereco.CEP;

            return $"{endereco.Logradouro}, {endereco.Complemento}, {endereco.Bairro}. {endereco.Cidade} - {endereco.UF}. CEP: {endereco.CEP}";
        }
    }
}
