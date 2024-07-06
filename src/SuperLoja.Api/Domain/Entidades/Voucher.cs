using FluentValidation.Results;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Validator;

namespace SuperLoja.Api.Domain.Entidades;

public class Voucher(bool ativo, string codigo, DateTime dataExpiracao, DateTime validoDesde, float taxa) : EntidadeBase
{
    public string Codigo { get; } = codigo;
    public bool Ativa { get; set; } = ativo;
    public DateTime ValidoDesde { get; private set; } = validoDesde;
    public DateTime DataExpiracao { get; private set; } = dataExpiracao;
    public float Taxa { get; } = taxa;

    public override ValidationResult Validar() 
        => new VoucherValidator().Validate(this);

    public bool EhAplicavel(DateTime date) 
        => Ativa && DataExpiracao >= date;

    public void Atualizar(AtualizaVoucherDto model)
    {
        Ativa = model.Ativo;
        DataExpiracao = model.DataExpiracao;
        ValidoDesde = model.ValidoDesde;
        UltimaAtualizacaoEm = DateTime.Now;
    }
}