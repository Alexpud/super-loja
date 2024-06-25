using AutoMapper;
using FluentResults;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Domain.Repository;
using SuperLoja.Api.Domain.Specs.Vouchers;

namespace SuperLoja.Api.Domain.Services;

public class VoucherService(IVoucherRepository voucherRepository, ILogger<VoucherService> logger, IMapper mapper)
{
    private readonly IVoucherRepository _voucherRepository = voucherRepository;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<VoucherService> _logger = logger;
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

    public Result Desativar(List<Guid> voucherIds)
    {
        var vouchers = _voucherRepository
            .AsQueryable()
            .Where(p => voucherIds.Contains(p.Id));

        if (!vouchers.Any())
            return new Result().WithError("Nenhum voucher foi encontrado");
        
        return DesativarVouchers(vouchers);
    }

    private Result DesativarVouchers(IQueryable<Voucher> vouchers)
    {
        var result = new Result();
        try
        {
            foreach (var bloco in vouchers.Chunk(500))
            {
                foreach (var voucher in bloco)
                {
                    voucher.Ativa = false;
                    _voucherRepository.Editar(voucher);
                }
                _voucherRepository.Commit();
                _logger.LogInformation("Message={Message}; VoucherIds={VoucherIds}",
                    "Vouchers foram desativados",
                    string.Join(';', bloco.Select(p => p.Id)));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Message={Message};", "A desativação de vouchers falhou para um conjunto de vouchers");
            result = result.WithError("A desativação de vouchers falhou para um conjunto de vouchers.");
        }

        return result;
    }

}