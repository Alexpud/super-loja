using System.ComponentModel.DataAnnotations;

namespace SuperLoja.Api.Presentation.ViewModel;

public class CadastrarProdutoViewModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "A propriedade Nome é obrigatória")]
    public string Nome { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "A propriedade Codigo é obrigatória")]
    public string Codigo { get; set; }
    
    [Required(AllowEmptyStrings = false, ErrorMessage = "A propriedade Marca é obrigatória")]
    public string Marca { get; set; }
    
    [Range(0, int.MaxValue)]
    [Required(AllowEmptyStrings = false, ErrorMessage = "A propriedade Quantidade é obrigatória")]
    public int Quantidade { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    public int QuantidadeMinima { get; set; }
    
    public float PesoUnitario { get; set; }
}
