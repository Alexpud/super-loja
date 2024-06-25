using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs.Vouchers;
using SuperLoja.Api.Tests.Builders;

namespace SuperLoja.Api.Tests.Domain.Specs.Vouchers;

public class VoucherComMesmoCodigoSpecificationTests
{
    [Fact]
    public void EhValido_DeveRetornarVoucherComMesmoCodigo()
    {
        // Arrange
        const string Codigo = "codigo";
        var spec = new VoucherComMesmoCodigoSpecification(Codigo);

        var vouchers = new List<Voucher>()
        {
            new VoucherBuilder().ComCodigo(Codigo).Build(),
            new VoucherBuilder().ComCodigo("Codigo diferente").Build()
        };

        // Act
        var vouchersComMesmoCodigo = vouchers.Where(spec.EhSatisfeito).ToList();

        // Assert
        Assert.Single(vouchersComMesmoCodigo);
        Assert.Equal(Codigo, vouchersComMesmoCodigo[0].Codigo);
    }
}