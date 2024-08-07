using AutoMapper;
using Microsoft.Extensions.Logging;
using MockQueryable.NSubstitute;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
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
    private readonly IMapper _mapper;
    private readonly ILogger<VoucherService> _logger;
    public VoucherServiceTests()
    {
        _voucherRepository = Substitute.For<IVoucherRepository>();
        _mapper = Substitute.For<IMapper>();
        _logger = Substitute.For<ILogger<VoucherService>>();
        _sut = new VoucherService(_voucherRepository, _logger, _mapper);
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
            .EncontrarTodos(Arg.Any<ISpecification<Voucher>>())
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
        _voucherRepository.EncontrarTodos(Arg.Any<ISpecification<Voucher>>())
            .Returns(new List<Voucher>().AsQueryable());

        var dto = new CadastrarVoucherDto
        {
            DataExpiracao = new DateTime(),
            Taxa = 0.5f,
            Codigo = "CODIGO"
        };   
        
        _mapper.Map<VoucherDto>(Arg.Any<Voucher>()).Returns(new VoucherDto());

        // Act
        var result = _sut.Cadastrar(dto);

        // Assert
        Assert.True(result.IsSuccess);
        _voucherRepository.Received(1).Commit();
    }

    [Fact]
    public void Desativar_DeveRetornarComErro_QuandoNenhumVoucherEEcontrado()
    {
        // Arrange
        var vouchers = new List<Voucher>().BuildMock();
        _voucherRepository.AsQueryable().Returns(vouchers);

        // Act
        var result = _sut.Desativar(new List<Guid>(){Guid.NewGuid()});

        // Assert
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Desativar_DeveRetornarComErro_QuandoDesativacaoDosVocuhersFalhar()
    {
        // Arrange
        var vouchers = new List<Voucher>()
        {
            new VoucherBuilder().Build()
        }.BuildMock();

        _voucherRepository
            .AsQueryable()
            .Returns(vouchers);

        _voucherRepository
            .When(p => p.Commit())
            .Do(_ => throw new Exception());

        // Act
        var result = _sut.Desativar(new List<Guid>() { vouchers.First().Id });

        // Assert
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Desativar_DeveRetornarComSucesso_QuandoVouchersPassadosForemDesativados()
    {
        // Arrange
        var vouchers = new List<Voucher>()
        {
            new VoucherBuilder().Build()
        }.BuildMock();
        
        _voucherRepository
            .AsQueryable()
            .Returns(vouchers);


        // Act
        var result = _sut.Desativar(new List<Guid>() { vouchers.First().Id });

        // Assert
        Assert.True(result.IsSuccess);
    }
}