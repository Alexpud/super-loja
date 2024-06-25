using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperLoja.Api.Presentation.ViewModels;

public class CadastrarProdutoViewModel
{
    [JsonRequired]
    [Required(AllowEmptyStrings = false, ErrorMessage = "A propriedade Nome é obrigatória")]
    public string Nome { get; set; }
    
    [JsonRequired]
    [Required(AllowEmptyStrings = false, ErrorMessage = "A propriedade Codigo é obrigatória")]
    public string Codigo { get; set; }
    
    [JsonRequired]
    [Required(AllowEmptyStrings = false, ErrorMessage = "A propriedade Marca é obrigatória")]
    public string Marca { get; set; }
    
    [JsonRequired]
    [Range(0, int.MaxValue)]
    public int Quantidade { get; set; }
    
    [JsonRequired]
    [Range(0, int.MaxValue)]
    public int QuantidadeMinima { get; set; }
    
    public float? PesoUnitario { get; set; }
}
