using AutoFixture;
using SuperLoja.Api.Domain.Entidades;
using SuperLoja.Api.Tests.Builders.Domain;

namespace SuperLoja.Api.Tests.Builders;
public class VoucherBuilder : BaseBuilder<Voucher, VoucherBuilder>
{
    private bool _ativa;
    private DateTime _dataExpiracao, _validoDesde;
    private float _taxa;
    private string _codigo;
    private readonly Fixture _fixture = new();

    public override VoucherBuilder BuildDefault()
    {
        _codigo = _fixture.Create<string>();
        _taxa = 0.5f;
        _validoDesde = new DateTime(2024, 1, 1);
        _dataExpiracao = _validoDesde.AddDays(1);
        return this;
    }

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

    public override Voucher Create()
    {
        var voucher = new Voucher(
            ativo: _ativa,
            codigo: _codigo,
            dataExpiracao: _dataExpiracao,
            validoDesde: _validoDesde,
            taxa: _taxa
        );
        return voucher;
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

    public VoucherBuilder ComValidoDesde(DateTime validoDesde)
    {
        _validoDesde = validoDesde;
        return this;
    }
}