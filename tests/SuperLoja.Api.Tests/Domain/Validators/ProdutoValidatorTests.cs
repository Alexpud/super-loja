using FluentValidation.TestHelper;
using SuperLoja.Api.Domain.Validator;
using SuperLoja.Api.Tests.Builders.Domain;

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
        var produto = new ProdutoBuilder().ComNome(nome).Create();

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
        var produto = new ProdutoBuilder().ComMarca(marca).Create();

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
        var produto = new ProdutoBuilder().ComCodigo(codigo).Create();

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.False(validationResult.IsValid);
        validationResult.ShouldHaveValidationErrorFor(p => p.Codigo);
    }

    [Fact]
    [Trait("Entidade", "Produto")]
    public void Validar_DeveRetornarComErro_QuandoQuantidadeEMenorQueZero()
    {
        // Arrange
        var produto = new ProdutoBuilder().ComQuantidade(-1).Create();

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
        var produto = new ProdutoBuilder().ComPropriedadesPreenchidas().Create();

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.True(validationResult.IsValid);
    }
}
