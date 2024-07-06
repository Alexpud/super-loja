using System.Text.Json.Serialization;

namespace SuperLoja.Api.Presentation.ViewModels;

public class CadastrarVoucherViewModel
{
    
    [JsonRequired]
    public DateTime DataExpiracao { get; set; }

    [JsonRequired]
    public DateTime ValidoDesde { get; set; }
    
    [JsonRequired]
    public float Taxa { get; set; }

    [JsonRequired]
    public string Codigo { get; set; }
}