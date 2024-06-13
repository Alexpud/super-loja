using System.Linq.Expressions;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

public class VoucherDisponivelSpecification(DateTime data) : LinqSpecification<Voucher>
{
    private readonly DateTime _date = data;

    protected override Expression<Func<Voucher, bool>> GetExpression()
    {
        return p => p.EstaDisponivel(_date);
    }
}