using System.Linq.Expressions;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Specs.Vouchers;

public class VoucherAplicavelSpecification(DateTime data) : LinqSpecification<Voucher>
{
    private readonly DateTime _date = data;

    protected override Expression<Func<Voucher, bool>> GetExpression()
    {
        return p => p.EhAplicavel(_date);
    }
}
