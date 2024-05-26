using FluentValidation.TestHelper;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Validator;

namespace SuperLoja.Api.Tests.Domain;

public class ProdutoValidatorTests
{
    private readonly ProdutoValidator _sut;
    public ProdutoValidatorTests()
    {
        _sut = new ProdutoValidator();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [Trait("Entidade", "Produto")]
    public void TestValidate_DeveRetornarComErroParaNome_QuandoNomeEInvalido(string nome)
    {
        // Assert
        var produto = new Produto()
        {
            Nome = nome
        };

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.False(validationResult.IsValid);
        validationResult.ShouldHaveValidationErrorFor(p => p.Nome);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [Trait("Entidade", "Produto")]
    public void Validar_DeveRetornarComErro_QuandoMarcaEInvalido(string marca)
    {
        // Assert
        var produto = new Produto()
        {
            Marca = marca
        };

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.False(validationResult.IsValid);
        validationResult.ShouldHaveValidationErrorFor(p => p.Marca);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [Trait("Entidade", "Produto")]
    public void Validar_DeveRetornarComErro_QuandoCodigoEInvalido(string codigo)
    {
        // Assert
        var produto = new Produto()
        {
            Codigo = codigo
        };

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.False(validationResult.IsValid);
        validationResult.ShouldHaveValidationErrorFor(p => p.Marca);
    }

    [Fact]
    [Trait("Entidade", "Produto")]
    public void Validar_DeveRetornarComErro_QuandoQuantidadeEMenorQueZero()
    {
        // Arrange
        var produto = new Produto()
        {
            Quantidade = -1
        };

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.False(validationResult.IsValid);
        validationResult.ShouldHaveValidationErrorFor(p => p.Quantidade);
    }

    [Fact]
    [Trait("Entidade", "Produto")]
    public void TestValidate_DeveSerValido_QuandoProdutoEValido()
    {
        // Arrange
        var produto = new Produto()
        {
            Nome = "Nome",
            Marca = "Uma marca",
            Quantidade = 0
        };

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.True(validationResult.IsValid);
    }
}
