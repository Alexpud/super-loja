using System.Data;
using FluentValidation;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Validator;

public class VoucherValidator : AbstractValidator<Voucher>
{
    public VoucherValidator()
    {
        RuleFor(p => p.Taxa)
            .GreaterThan(0)
            .WithMessage("{PropertyName} deve ser maior que zero")
            .LessThanOrEqualTo(1)
            .WithMessage("{PropertyName} deve ser inferior ou igual a 1");
        RuleFor(p => p.Codigo).NotEmpty().WithMessage("{PropertyName} é obrigatória");
    }
}
