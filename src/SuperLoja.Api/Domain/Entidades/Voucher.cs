using FluentValidation.Results;
using SuperLoja.Api.Domain.Validator;

namespace SuperLoja.Api.Domain.Entidades;

public class Voucher(bool ativo, string codigo, DateTime dataExpiracao, float taxa) : EntidadeBase
{
    public string Codigo { get; } = codigo;
    public bool Ativa { get; set; } = ativo;
    public DateTime DataExpiracao { get; } = dataExpiracao;
    public float Taxa { get; } = taxa;

    public override ValidationResult Validar() 
        => new VoucherValidator().Validate(this);

    public bool EhAplicavel(DateTime date) 
        => Ativa && DataExpiracao >= date;
}