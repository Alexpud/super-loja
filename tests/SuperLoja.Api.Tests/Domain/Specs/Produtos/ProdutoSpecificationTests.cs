using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;
using SuperLoja.Api.Domain.Specs.Produtos;

namespace SuperLoja.Api.Tests.Builders.Domain.Specs.Produtos;

public class ProdutoSpecificationTests
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
        var item = lista.Where(new ProdutosPorCodigoSpecification(Codigo).EhSatisfeito)
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
        var item = lista.Where(new ProdutosPorNomeSpecification(Nome).EhSatisfeito)
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
        var item = lista.Where(new ProdutosPorMarcaSpecification(Marca).EhSatisfeito)
            .FirstOrDefault();

        // Assert
        Assert.NotNull(item);
    }
}
