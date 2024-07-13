using FluentValidation;

namespace SuperLoja.Api.Domain.Entidades;

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {
        RuleFor(p => p.Nome).NotEmpty();
        RuleFor(p => p.Marca).NotEmpty();
        RuleFor(p => p.Codigo).NotEmpty();
        RuleFor(p => p.Quantidade).GreaterThanOrEqualTo(0);
    }
}
