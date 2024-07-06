namespace SuperLoja.Api.Domain.Dtos;

public class AtualizaVoucherDto
{
    public Guid Id { get; set; }
    public DateTime ValidoDesde{ get; set; }

    public DateTime DataExpiracao { get; set; }
    public bool Ativo { get; set; }
}