using NSubstitute;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Services;
using SuperLoja.Api.Domain.Specs;
using SuperLoja.Api.Tests.Builders;

namespace SuperLoja.Api.Tests.Domain.Services;

public class VoucherServiceTests
{
    private readonly VoucherService _sut;
    private readonly IVoucherRepository _voucherRepository;
    public VoucherServiceTests()
    {
        _voucherRepository = Substitute.For<IVoucherRepository>();
        _sut = new VoucherService(_voucherRepository);
    }

    [Fact]
    public void Cadastrar_DeveRetornarComErro_QuandoVoucherForInvalidoParaCadastro()
    {
        // Arrange
        var dto = new CadastrarVoucherDto
        {
            DataExpiracao = new DateTime(),
            Taxa = -3
        };

        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsFailed);
    }

    [Fact]
    public void Cadastrar_DeveRetornarComErro_QuandoVoucherComMesmoCodigoExiste()
    {
        // Arrange
        const string Codigo = "Codigo";
        _voucherRepository
            .ObterPorSpecification(Arg.Any<ISpecification<Voucher>>())
            .Returns(new List<Voucher>()
            {
                new VoucherBuilder().ComCodigo(Codigo).Build()
            }.AsQueryable());
        
        var dto = new CadastrarVoucherDto
        {
            DataExpiracao = new DateTime(),
            Taxa = 2,
            Codigo = Codigo
        };   

        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsFailed);
    }

    [Fact]
    public void Cadastrar_DeveRetornarComSucesso_QuandoVoucherValidoEUnico()
    {
        // Arrange
        _voucherRepository.ObterPorSpecification(Arg.Any<ISpecification<Voucher>>())
            .Returns(new List<Voucher>().AsQueryable());

        var dto = new CadastrarVoucherDto
        {
            DataExpiracao = new DateTime(),
            Taxa = 2,
            Codigo = "CODIGO"
        };   
        
        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsSuccess);
        _voucherRepository.Received(1).Commit();
    }
}