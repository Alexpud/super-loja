using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Specs;

namespace SuperLoja.Api.Tests.Builders.Domain;

public class ProdutoComMesmoCodigoSpecificationTests
{
    [Fact]
    public void EhSatisfeito_DeveRetornarTrue_QuandoProdutoComMesmoCodigoExisteNaLista()
    {
        // Arrange
        var lista = new List<Produto>()
        {
            new ProdutoBuilder().BuildDefault().ComCodigo("codigo").Create()
        };

        // Act
        var item = lista.Where(new ProdutoComMesmoCodigoSpecification("codigo").EhSatisfeito)
            .FirstOrDefault();

        // Assert
        Assert.NotNull(item);
    }
}
