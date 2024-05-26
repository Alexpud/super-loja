using FluentValidation;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Validator;

public class ProdutoValidator : AbstractValidator<Produto>
{
    public ProdutoValidator()
    {
        RuleFor(p => p.Nome).NotEmpty();
        RuleFor(p => p.Marca).NotEmpty();
        RuleFor(p => p.Quantidade).GreaterThanOrEqualTo(0);
    }
}
