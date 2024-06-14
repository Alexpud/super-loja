using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Services;

namespace SuperLoja.Api.Tests.Domain.Services;

public class VoucherServiceTests
{
    private readonly VoucherService _sut;
    public VoucherServiceTests()
    {
        _sut = new VoucherService();
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
        erro
    }
}