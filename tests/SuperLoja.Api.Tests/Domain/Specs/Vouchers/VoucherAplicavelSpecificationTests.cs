using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs.Vouchers;
using SuperLoja.Api.Tests.Builders;

namespace SuperLoja.Api.Tests.Domain.Specs.Vouchers;

public class VoucherAplicavelSpecificationTests 
{
    [Fact]
    public void EhValido_NaoDeveRetornarVouchers_QuandoNaoHouverVouchersDisponiveis()
    {
        // Arrange
        var date = new DateTime(2024, 1, 1);
        var spec = new VoucherAplicavelSpecification(date);
        var vouchers = new List<Voucher>()
        {
            new VoucherBuilder().EhAtiva(true).ComDataExpiracao(date.AddMonths(-1)).Create(),
            new VoucherBuilder().EhAtiva(false).ComDataExpiracao(date.AddMonths(4)).Create()
        };

        // Act
        var promocoesAtivas = vouchers.Where(spec.EhSatisfeito);

        // Assert
        Assert.Empty(promocoesAtivas);
    }

    [Fact]
    public void EhValido_DeveRetornarVouchersDisponiveis_QUandoHouverVouchersDisponiveis()
    {
        // Arrange
        var date = new DateTime(2024, 1, 1);
        var spec = new VoucherAplicavelSpecification(date);
        var vouchers = new List<Voucher>()
        {
            new VoucherBuilder().EhAtiva(true).ComDataExpiracao(date.AddMonths(1)).Create(),
            new VoucherBuilder().EhAtiva(false).ComDataExpiracao(date.AddMonths(4)).Create()
        };

        // Act
        var promocoesAtivas = vouchers.Where(spec.EhSatisfeito);

        // Assert
        Assert.Single(promocoesAtivas);
    }
}
