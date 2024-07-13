using FluentValidation.Results;

namespace SuperLoja.Api.Domain.Entidades;

public class Voucher : EntidadeBase
{
    public string Codigo { get; private set; }
    public bool Ativa { get; set; } 
    public DateTime DataExpiracao { get; private set; } 
    public float Taxa { get; private set; } 

    private Voucher() { }
    public Voucher(bool ativo, string codigo, DateTime dataExpiracao, float taxa)
    {
        Codigo = codigo;
        Ativa = ativo;
        DataExpiracao = dataExpiracao;
        Taxa = taxa;
    }

    public override ValidationResult Validar() 
        => new VoucherValidator().Validate(this);

    public bool EhAplicavel(DateTime date) 
        => Ativa && DataExpiracao >= date;
}