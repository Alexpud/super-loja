using FluentValidation.TestHelper;
using SuperLoja.Api.Domain.Validator;
using SuperLoja.Api.Tests.Builders;

namespace SuperLoja.Api.Tests.Domain.Validators;


public class VoucherValidatorTests
{
    private readonly VoucherValidator _sut = new();
    
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void TestValidate_DeveTerErroParaTaxa_QuandoElaForInvalida(float taxa)
    {
        // Arrange
        var voucher = new VoucherBuilder().ComTaxa(taxa).Build();

        // Act
        var validation = _sut.TestValidate(voucher);

        // Assert
        validation.ShouldHaveValidationErrorFor(p => p.Taxa);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void TestValidate_DeveTerErroParaCodigo_QuandoValorForInvalido(string codigo)
    {
        // Arrange
        var voucher = new VoucherBuilder().ComCodigo(codigo).Build();

        // Act
        var validation = _sut.TestValidate(voucher);

        // Assert
        validation.ShouldHaveValidationErrorFor(p => p.Codigo);
    }

    [Fact]
    public void TestValidate_DeveRetornarSemErros_QuandoVoucherForValido()
    {
        // Arrange
        var voucher = new VoucherBuilder().ComTaxa(1).ComCodigo("asdsa").Build();

        // Act
        var validation = _sut.TestValidate(voucher);

        // Assert
        Assert.True(validation.IsValid);
    }
}