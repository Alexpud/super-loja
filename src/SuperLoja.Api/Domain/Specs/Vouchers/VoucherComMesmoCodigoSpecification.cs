using System.Linq.Expressions;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Specs.Vouchers;

public class VoucherComMesmoCodigoSpecification(string codigo) : LinqSpecification<Voucher>
{
    private readonly string _codigo = codigo;
    protected override Expression<Func<Voucher, bool>> GetExpression()
    {
        return p => p.Codigo == _codigo;
    }

}