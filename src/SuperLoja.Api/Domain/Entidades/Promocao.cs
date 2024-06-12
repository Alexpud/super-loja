using FluentValidation.Results;

namespace SuperLoja.Api.Domain.Entidades;

public class Promocao(bool ativa, DateTime dataExpiracao, float taxa) : EntidadeBase
{
    public bool Ativa { get; set; } = ativa;
    public DateTime DataExpiracao { get; } = dataExpiracao;
    public float Taxa { get; } = taxa;

    public override ValidationResult Validar()
    {
        throw new NotImplementedException();
    }

    public bool EstaDisponivel(DateTime date) 
        => Ativa && DataExpiracao >= date;
}