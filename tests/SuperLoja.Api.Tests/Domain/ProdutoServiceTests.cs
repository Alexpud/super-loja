using AutoFixture;
using MockQueryable.NSubstitute;
using NSubstitute;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Services;
using SuperLoja.Api.Tests.Builders.Domain;

namespace SuperLoja.Api.Tests.Domain;

public class ProdutoServiceTests
{
    private readonly ProdutoService _sut;
    private readonly IProdutoRepository _produtoRepository;
    private readonly Fixture _fixture = new();
    public ProdutoServiceTests()
    {
        _produtoRepository = Substitute.For<IProdutoRepository>();
        _sut = new ProdutoService(_produtoRepository);
    }

    [Fact]
    [Trait("Entidade", "Produto")]
    public void Cadastrar_DeveRetornarComErro_QuandoDadosDeCadastroSaoInvalidos()
    {
        // Arrange
        var dto = new CadastrarProdutoDto();

        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsFailed);
    }

    [Fact]
    [Trait("Entidade", "Produto")]
    public void Cadastrar_DeveRetornarComErro_QuandoProdutoComMesmoCodigoExiste()
    {
        // Arrage
        var codigo = "codigo";
        var produtos = new List<Produto>()
        {
            new ProdutoBuilder().BuildDefault().ComCodigo(codigo).Create()
        }.BuildMock();

        _produtoRepository.AsQueryable().Returns(produtos);

        var dto = new CadastrarProdutoDto()
        {
            Nome = _fixture.Create<string>(),
            Marca = _fixture.Create<string>(),
            Codigo = codigo,
            PesoUnitario = 1,
            Quantidade = 1
        };

        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsFailed);
    }


    [Fact]
    [Trait("Entidade", "Produto")]
    public void Cadastrar_DeveRetornarComErro_QuandoProdutoComMesmoNomeEMarcaExistem()
    {
        // Arrage
        var marca = "marca";
        var nome = "nome";
        var produtos = new List<Produto>()
        {
            new ProdutoBuilder()
                .BuildDefault()
                .ComNome(nome)
                .ComMarca(marca)
                .Create()
        }.BuildMock();

        _produtoRepository.AsQueryable().Returns(produtos);

        var dto = new CadastrarProdutoDto()
        {
            Nome = nome,
            Marca = marca,
            Codigo = "codigo",
            PesoUnitario = 1,
            Quantidade = 1
        };

        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsFailed);
    }

    [Fact]
    [Trait("Entidade", "Produto")]
    public void Cadastrar_DeveRetornarProdutoCriado_QuandoForBemSucedido()
    {
        // Arrage
        var produtos = new List<Produto>().BuildMock();

        _produtoRepository.AsQueryable().Returns(produtos);

        var dto = new CadastrarProdutoDto()
        {
            Nome = "Algum nome",
            Marca = "Alguma marca",
            Codigo = "codigo",
            PesoUnitario = 1,
            Quantidade = 1
        };

        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsSuccess);
    }
}
