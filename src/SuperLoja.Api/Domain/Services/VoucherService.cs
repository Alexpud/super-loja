using FluentResults;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs.Vouchers;

namespace SuperLoja.Api.Domain.Services;

public class VoucherService(IVoucherRepository voucherRepository)
{
    private readonly IVoucherRepository _voucherRepository = voucherRepository;
    public Result<Voucher> Cadastrar(CadastrarVoucherDto dto)
    {
        var voucher = new Voucher(
            ativo: false,
            codigo: dto.Codigo,
            dataExpiracao: dto.DataExpiracao,
            taxa: dto.Taxa);

        var validationResult = ValidarCadastroVoucher(voucher);
        if (validationResult.IsFailed)
            return validationResult;

        _voucherRepository.Adicionar(voucher);
        _voucherRepository.Commit();
        return new Result<Voucher>().WithValue(voucher);
    }

    private Result<Voucher> ValidarCadastroVoucher(Voucher voucher)
    {
        var result = new Result<Voucher>();
        var validation = voucher.Validar();
        if (!validation.IsValid)
            result = result.WithError("Dados invalidos de cadastro de voucher");

        var vouchers = _voucherRepository.ObterPorSpecification(new VoucherComMesmoCodigoSpecification(voucher.Codigo));
        if (vouchers.Any())
            result = result.WithError("Ja existe um voucher com o mesmo código");
        
        return result;
    }
}