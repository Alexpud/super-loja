using System.Linq.Expressions;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Specs.Vouchers;

public class VoucherComMesmoCodigoSpecification : BaseSpecification<Voucher>
{
    public VoucherComMesmoCodigoSpecification(string codigo)
    {
        expression = voucher => voucher.Codigo == codigo;
    }
}

public class VoucherAplicavelSpecification : BaseSpecification<Voucher>
{
    public VoucherAplicavelSpecification(DateTime data)
    {
        expression = voucher => voucher.EhAplicavel(data);
    }
}
