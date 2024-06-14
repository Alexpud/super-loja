namespace SuperLoja.Api.Domain.Dtos;

public class CadastrarVoucherDto
{
    public DateTime DataExpiracao { get; set; }
    public float Taxa { get; set; }
    public string Codigo { get; set; }
}