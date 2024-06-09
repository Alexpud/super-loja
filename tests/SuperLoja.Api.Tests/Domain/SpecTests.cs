using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;
using SuperLoja.Api.Domain.Specs.Produtos;

namespace SuperLoja.Api.Tests.Builders.Domain;

public class SpecTests
{
    [Fact]
    public void ProdutoComMesmoCodigoSpecification_DeveRetornarTrue_QuandoProdutoComMesmoCodigoExisteNaLista()
    {
        // Arrange
        const string Codigo = "codigo";
        var lista = new List<Produto>()
        {
            new ProdutoBuilder().ComCodigo(Codigo).Build()
        };

        // Act
        var item = lista.Where(new ProdutoComMesmoCodigoSpecification(Codigo).EhSatisfeito)
            .FirstOrDefault();

        // Assert
        Assert.NotNull(item);
    }

    [Fact]
    public void ProdutoComMesmoNomeSpecification_DeveRetornarTrue_QuandoProdutoComMesmoNomeExisteNaLista()
    {
        // Arrange
        const string Nome = "Nome";
        var lista = new List<Produto>()
        {
            new ProdutoBuilder().ComNome(Nome).Build()
        };

        // Act
        var item = lista.Where(new ProdutoComMesmoNomeSpecification(Nome).EhSatisfeito)
            .FirstOrDefault();

        // Assert
        Assert.NotNull(item);
    }

    [Fact]
    public void ProdutoComMesmaMarcaSpecification_DeveRetornarTrue_QuandoProdutoComMesmaMarcaExisteNaLista()
    {
        // Arrange
        const string Marca = "marca";
        var lista = new List<Produto>()
        {
            new ProdutoBuilder().ComMarca(Marca).Build()
        };

        // Act
        var item = lista.Where(new ProdutoComMesmaMarcaSpecification(Marca).EhSatisfeito)
            .FirstOrDefault();

        // Assert
        Assert.NotNull(item);
    }
}
