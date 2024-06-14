using FluentResults;
using SuperLoja.Api.Domain.Dtos;
using SuperLoja.Api.Domain.Entidades;

namespace SuperLoja.Api.Domain.Services;

public class VoucherService
{
    public Result<Voucher> Cadastrar(CadastrarVoucherDto dto)
    {
        var voucher = new Voucher(
            ativo: false, 
            codigo: dto.Codigo, 
            dataExpiracao: dto.DataExpiracao, 
            taxa: dto.Taxa);
        var validation = voucher.Validar();
        if (!validation.IsValid)
            return new Result<Voucher>().WithError("Dados invalidos de cadastro de voucher");
        throw new NotImplementedException();
    }

}