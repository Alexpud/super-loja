using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Tests.Builders.Domain;

namespace SuperLoja.Api.Tests.Builders;
public class VoucherBuilder : BaseBuilder<Voucher, VoucherBuilder>
{
    private bool _ativa;
    private DateTime _dataExpiracao;
    private float _taxa;
    private string _codigo;

    public VoucherBuilder EhAtiva(bool ehAtivada)
    {
        _ativa = ehAtivada;
        return this;
    }

    public VoucherBuilder ComDataExpiracao(DateTime dateTime)
    {
        _dataExpiracao = dateTime;
        return this;
    }

    public override Voucher Build()
    {
        return new Voucher(
            ativo: _ativa,
            codigo: _codigo,
            dataExpiracao: _dataExpiracao,
            taxa: _taxa
        );
    }

    public VoucherBuilder ComTaxa(float taxa)
    {
        _taxa = taxa;
        return this;
    }

    public VoucherBuilder ComCodigo(string codigo)
    {
        _codigo = codigo;
        return this;
    }
}