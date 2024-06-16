namespace SuperLoja.Api.Domain.Dtos;

public class VoucherDto
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }
    public bool Ativa { get; set; }
    public DateTime DataExpiracao { get; set; }
    public float Taxa { get; set; }
}