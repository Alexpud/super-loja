using System.ComponentModel.DataAnnotations;

namespace SuperLoja.Api.Presentation.ViewModels;

public class CadastrarVoucherViewModel
{
    [Required(ErrorMessage = "A {PropertyName} é obrigatória")]
    public DateTime DataExpiracao { get; set; }

    [Required]
    [Range(minimum: 0, maximum: 1.0, ErrorMessage = "O valor da taxa temm que ser maior que zero e menor que 1.0")]
    public float Taxa { get; set; }

    [Required(AllowEmptyStrings = false, ErrorMessage = "{PropertyName} é obrigatório")]
    public string Codigo { get; set; }
}