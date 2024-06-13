using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Tests.Builders;

namespace SuperLoja.Api.Tests.Domain.Specs.Vouchers;

public class VoucherDisponivelSpecificationTests 
{
    [Fact]
    public void EhValido_NaoDeveRetornarPromocoes_QuandoNaoHouverPromocoesDisponiveis()
    {
        // Arrange
        var date = new DateTime(2024, 1, 1);
        var spec = new VoucherDisponivelSpecification(date);
        var promocoes = new List<Voucher>()
        {
            new VoucherBUilder().EhAtiva(true).ComDataExpiracao(date.AddMonths(-1)).Build(),
            new VoucherBUilder().EhAtiva(false).ComDataExpiracao(date.AddMonths(4)).Build()
        };

        // Act
        var promocoesAtivas = promocoes.Where(spec.EhSatisfeito);

        // Assert
        Assert.Empty(promocoesAtivas);
    }

    [Fact]
    public void EhValido_DeveRetornarPromocoesDisponiveis_QUandoHouverPromocoesDisponiveis()
    {
        // Arrange
        var date = new DateTime(2024, 1, 1);
        var spec = new VoucherDisponivelSpecification(date);
        var promocoes = new List<Voucher>()
        {
            new VoucherBUilder().EhAtiva(true).ComDataExpiracao(date.AddMonths(1)).Build(),
            new VoucherBUilder().EhAtiva(false).ComDataExpiracao(date.AddMonths(4)).Build()
        };

        // Act
        var promocoesAtivas = promocoes.Where(spec.EhSatisfeito);

        // Assert
        Assert.Single(promocoesAtivas);
    }
}