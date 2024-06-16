using AutoMapper;
using FluentResults;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs.Vouchers;

namespace SuperLoja.Api.Domain.Services;

public class VoucherService(IVoucherRepository voucherRepository, IMapper mapper)
{
    private readonly IVoucherRepository _voucherRepository = voucherRepository;
    private readonly IMapper _mapper = mapper;
    public Result<VoucherDto> Cadastrar(CadastrarVoucherDto dto)
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
        return new Result<VoucherDto>().WithValue(_mapper.Map<VoucherDto>(voucher));
    }

    private Result<VoucherDto> ValidarCadastroVoucher(Voucher voucher)
    {
        var result = new Result<VoucherDto>();
        var validation = voucher.Validar();
        if (!validation.IsValid)
            result = result.WithError("Dados invalidos de cadastro de voucher");

        var vouchers = _voucherRepository.ObterPorSpecification(new VoucherComMesmoCodigoSpecification(voucher.Codigo));
        if (vouchers.Any())
            result = result.WithError("Ja existe um voucher com o mesmo código");
        
        return result;
    }
}