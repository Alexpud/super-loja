using AutoFixture;
using FluentValidation.TestHelper;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Validator;
using SuperLoja.Api.Tests.Builders.Domain;

namespace SuperLoja.Api.Tests.Domain;

public class ProdutoValidatorTests
{
    private readonly ProdutoValidator _sut;
    private readonly Fixture _fixture;
    public ProdutoValidatorTests()
    {
        _fixture = new Fixture();
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
        var produto = new ProdutoBuilder();

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
        var produto = new Produto(
            nome: _fixture.Create<string>(),
            codigo: _fixture.Create<string>(),
            marca: marca,
            quantidade: _fixture.Create<int>(),
            quantidadeMinima: _fixture.Create<int>(),
            pesoUnitario: _fixture.Create<float>());

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
        var produto = new Produto(
            nome: _fixture.Create<string>(),
            codigo: codigo,
            marca: _fixture.Create<string>(),
            quantidade: _fixture.Create<int>(),
            quantidadeMinima: _fixture.Create<int>(),
            pesoUnitario: _fixture.Create<float>());
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
        var produto = new Produto(
            nome: _fixture.Create<string>(),
            codigo: _fixture.Create<string>(),
            marca: _fixture.Create<string>(),
            quantidade: -1,
            quantidadeMinima: _fixture.Create<int>(),
            pesoUnitario: _fixture.Create<float>());

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
        var produto = new Produto(
            nome: _fixture.Create<string>(),
            codigo: _fixture.Create<string>(),
            marca: _fixture.Create<string>(),
            quantidade: 2,
            quantidadeMinima: _fixture.Create<int>(),
            pesoUnitario: _fixture.Create<float>());

        // Act
        var validationResult = _sut.TestValidate(produto);

        // Assert
        Assert.True(validationResult.IsValid);
    }
}
