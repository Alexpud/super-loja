using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Tests.Builders.Domain;

namespace SuperLoja.Api.Tests.Builders;
public class VoucherBUilder : BaseBuilder<Voucher, VoucherBUilder>
{
    private bool _ativa;
    private DateTime _dataExpiracao;
    private float _taxa;
    
    public override VoucherBUilder ComPropriedadesPreenchidas()
    {
        throw new NotImplementedException();
    }

    public VoucherBUilder EhAtiva(bool ehAtivada)
    {
        _ativa = ehAtivada;
        return this;
    }

    public VoucherBUilder ComDataExpiracao(DateTime dateTime)
    {
        _dataExpiracao = dateTime;
        return this;
    }

    public override Voucher Build()
    {
        return new Voucher(
            ativa: _ativa,
            dataExpiracao: _dataExpiracao,
            taxa: _taxa
        );
    }
}